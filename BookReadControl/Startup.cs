using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookReadControl.Data;
using BookReadControl.Data.Interfaces;
using BookReadControl.Data.mocks;
using BookReadControl.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookReadControl
{
    public class Startup
    {

        private IConfigurationRoot _dbConfiguration;

        public Startup(IWebHostEnvironment host)
        {
            _dbConfiguration = new ConfigurationBuilder()
                 .SetBasePath(host.ContentRootPath)
                 .AddJsonFile("appSettingsDB.json")
                 .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Пример подключения БД
            //services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_dbConfiguration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IBooks, MockBooks>();
            services.AddTransient<IBooksTypes, MockType>();
            services.AddSingleton<IUser, MockUser>();
            services.AddSingleton<ILibrary, MockLibrary>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvcWithDefaultRoute();
        }
    }

}