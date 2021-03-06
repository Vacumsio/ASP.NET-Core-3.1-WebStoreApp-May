﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebStoreApp.DAL.Context;
using WebStoreApp.Domain.Entities.Identity;

namespace WebStoreApp.Services.Data
{
    public class WebStoreDBInitializer
    {
        private readonly WebStoreDB _db;
        private readonly UserManager<User> _UserManager;
        private readonly RoleManager<Role> _RoleManager;
        private readonly ILogger<WebStoreDBInitializer> _Logger;

        public WebStoreDBInitializer(WebStoreDB db, UserManager<User> UserManager, RoleManager<Role> RoleManager, ILogger<WebStoreDBInitializer> Logger)
        {
            _db = db;
            _UserManager = UserManager;
            _RoleManager = RoleManager;
            _Logger = Logger;
        }

        public void Initialize()
        {
            var db = _db.Database;
            //db.Migrate();

            if (db.GetPendingMigrations().Any())
            {
                _Logger.LogInformation("Подготовка к выполнению миграции БД");
                db.Migrate();
                _Logger.LogInformation("Миграция БД выполнена успешно");
            }

            InitializeEmployee();
            InitializeProducts();
            InitializeIdentityAsync().Wait();
        }
        private void InitializeEmployee()
        {
            var db = _db.Database;

            if (_db.Employees.Any()) return;

            using (db.BeginTransaction())
            {
                var employees = TestData.Employees.ToList();
                employees.ForEach(e => e.Id = 0);
                _db.Employees.AddRange(employees);

                _db.SaveChanges();
                db.CommitTransaction();
            }
        }

        private void InitializeProducts()
        {
            var db = _db.Database;

            if (_db.Products.Any()) return;

            using (db.BeginTransaction())
            {
                _db.Sections.AddRange(TestData.Sections);

                db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProductSection] ON");
                _db.SaveChanges();
                db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProductSection] OFF");

                db.CommitTransaction();
            }

            using (var transaction = db.BeginTransaction())
            {
                _db.Brands.AddRange(TestData.Brands);

                db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProductBrand] ON");
                _db.SaveChanges();
                db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProductBrand] OFF");

                transaction.Commit();
            }

            using (var transaction = db.BeginTransaction())
            {
                _db.Products.AddRange(TestData.Products);

                db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] ON");
                _db.SaveChanges();
                db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] OFF");

                transaction.Commit();
            }
        }

        private async Task InitializeIdentityAsync()
        {
            if (!await _RoleManager.RoleExistsAsync(Role.Administrator))
            {
                await _RoleManager.CreateAsync(new Role { Name = Role.Administrator });
            }

            if (!await _RoleManager.RoleExistsAsync(Role.User))
            {
                await _RoleManager.CreateAsync(new Role { Name = Role.User });
            }

            if (await _UserManager.FindByNameAsync(User.Administrator) is null)
            {
                var admin = new User { UserName = User.Administrator };
                var create_result = await _UserManager.CreateAsync(admin, User.Password);
                if (create_result.Succeeded)
                {
                    await _UserManager.AddToRoleAsync(admin, Role.Administrator);
                }
                else
                {
                    var errors = create_result.Errors.Select(e => e.Description);
                    throw new InvalidOperationException($"Ошибка создания пользователя с ролью Администратор{string.Join(",", errors)}");
                }
            }
        }
    }
}
