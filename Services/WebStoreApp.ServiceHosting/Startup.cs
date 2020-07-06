using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.OpenApi.Models;
using WebStoreApp.DAL.Context;
using WebStoreApp.Domain.Entities.Identity;
using WebStoreApp.Interfaces.Services;
using WebStoreApp.Services.Data;
using WebStoreApp.Services.Products.InSQL;
using WebStoreApp.Logger;

namespace WebStoreApp.ServiceHosting
{
    /// <summary>
    /// Конфигурирование данных и сервисов
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration) => Configuration = configuration;
        /// <summary>
        /// Поле для инициализации данных полученных в консрукторе класса
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Конфигурация приложения
        /// </summary>
        /// <param name="services"></param>
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

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "WebStoreApp.Api ", Version = "v1" });

                const string web_domain_xml = "WebStoreApp.Domain.xml";
                const string web_api_xml = "WebStoreApp.ServiceHosting.xml";
                const string debug_path = "bin/debug/netcoreapp3.1";

                opt.IncludeXmlComments(web_api_xml);
                if (File.Exists(web_domain_xml))
                    opt.IncludeXmlComments(web_domain_xml);
                else if (File.Exists(Path.Combine(debug_path, web_domain_xml)))
                    opt.IncludeXmlComments(Path.Combine(debug_path, web_domain_xml));
            });


            services.AddScoped<IEmployeesData, SqlEmployeeData>()
            .AddScoped<IProductData, SqlProductData>()
            .AddScoped<IOrderService, SqlOrderService>();
        }
        /// <summary>
        /// Конфигурация приложения
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="db"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WebStoreDBInitializer db, ILoggerFactory log)
        {
            log.AddLog4Net();

            db.Initialize();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "WebStoreApp.Api");
                opt.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
