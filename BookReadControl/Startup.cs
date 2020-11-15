using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookReadControl.Data;
using BookReadControl.Data.Interfaces;
using BookReadControl.Data.mocks;
using BookReadControl.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookReadControl
{
    public class Startup
    {
        private readonly IConfigurationRoot _dbConfiguration;

        public Startup(IWebHostEnvironment host)
        {
            _dbConfiguration = new ConfigurationBuilder()
                 .SetBasePath(host.ContentRootPath)
                 .AddJsonFile("appSettingsDB.json")
                 .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_dbConfiguration.GetConnectionString("DefaultConnection")));

            //services.AddTransient<IBooks, MockBooks>();
            //services.AddTransient<IBooksTypes, MockType>();
            //services.AddSingleton<IUser, MockUser>();
            //services.AddSingleton<ILibrary, MockLibrary>();
            services.AddTransient<IBooks, BookRepository>();
            services.AddTransient<IBooksTypes, TypeRepository>();
            services.AddTransient<IUser, UserRepository>();
            services.AddTransient<ILibrary, LibraryRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "TypeFilter", template: "Books/{action}/{typeName?}", defaults: new { Controller = "Books", action = "BooksList" });
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                UpdateDataBase.Update(scope.ServiceProvider.GetRequiredService<AppDBContent>());
            }
        }
    }

}