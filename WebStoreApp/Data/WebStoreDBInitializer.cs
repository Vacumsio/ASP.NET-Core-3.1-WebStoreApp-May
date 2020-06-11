﻿using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebStoreApp.DAL.Context;

namespace WebStoreApp.Data
{
    public class WebStoreDBInitializer
    {
        private readonly WebStoreDB _db;
        public WebStoreDBInitializer(WebStoreDB db) => _db = db;

        public void Initialize()
        {    
            
            var db = _db.Database;
            
            db.Migrate();
            if (!_db.Employees.Any())
            {
                using (db.BeginTransaction())
                {
                    var employees = TestData.Employees.ToList();
                    employees.ForEach(e => e.Id = 0);
                    _db.Employees.AddRange(employees);
                }
            }
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
    }
}