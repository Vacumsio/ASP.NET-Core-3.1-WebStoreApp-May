using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebStoreApp.DAL.Context;
using WebStoreApp.Domain.Entities.Identity;
using WebStoreApp.Interfaces.Services;
using WebStoreApp.Services.Data;
using WebStoreApp.Services.Products.InSQL;

namespace WebStoreApp.ServiceHosting
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {


            services.AddDbContext<WebStoreDB>(opt =>
                 opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<WebStoreDBInitializer>();

            services.AddIdentity<User, Role>()
              .AddEntityFrameworkStores<WebStoreDB>()
              .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(opt =>
            {
#if DEBUG
                opt.Password.RequiredLength = 3;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredUniqueChars = 3;

                //opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCD1234567890";
                opt.User.RequireUniqueEmail = false;
#endif

                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.MaxFailedAccessAttempts = 10;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            });
            services.AddControllers();

            services.AddScoped<IEmployeesData, SqlEmployeeData>()
            .AddScoped<IProductData, SqlProductData>()
            .AddScoped<IOrderService, SqlOrderService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WebStoreDBInitializer db)
        {
            db.Initialize();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}