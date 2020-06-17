using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using WebStoreApp.DAL.Context;
using WebStoreApp.Data;
using WebStoreApp.Domain.Entities.Identity;
using WebStoreApp.Infrastructure.Interfaces;
using WebStoreApp.Infrastructure.Services;
using WebStoreApp.Infrastructure.Services.InSQL;

namespace WebStoreApp
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WebStoreDB>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<WebStoreDBInitializer>();

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<WebStoreDB>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(opt =>
           {
               opt.Password.RequiredLength = 3;
               opt.Password.RequireDigit = false;
               opt.Password.RequireLowercase = false;
               opt.Password.RequireUppercase = false;
               opt.Password.RequiredUniqueChars = 3;
               opt.Password.RequireNonAlphanumeric = false;

               opt.User.RequireUniqueEmail = false;

               opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
               opt.Lockout.MaxFailedAccessAttempts = 3;
               opt.Lockout.AllowedForNewUsers = true;
           });

            services.ConfigureApplicationCookie(opt=> {
                opt.Cookie.Expiration = TimeSpan.FromDays(14);
                opt.Cookie.Name = "WebStoreApp.AtAzure.AtLeast";
                opt.Cookie.HttpOnly = true;

                opt.LoginPath = "";
                opt.AccessDeniedPath = "";
                opt.LogoutPath = "";
                opt.SlidingExpiration = true;
            });

            services.AddAuthentication();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            //services.AddSingleton<IEmployeesData, InMemoryEmpolyeeData>();
            //services.AddSingleton<IProductData, InMemoryProductData>();
            services.AddScoped<IProductData, SqlProductData>();
            services.AddScoped<IEmployeesData, SqlEmployeeData>();

            /*Добавить AutoMapper. 
             -
            -
            -
            -
            -
            -
            -*/
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WebStoreDBInitializer db)
        {
            db.Initialize();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
