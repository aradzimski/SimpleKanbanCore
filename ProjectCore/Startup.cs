using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProjectCore.Context;
using ProjectCore.Models;
using ProjectCore.Repositories;

namespace ProjectCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<ProjectCoreContext>(options =>
                options.UseSqlite("DataSource=dbo.ProjectCore.db",
                    builder => builder.MigrationsAssembly("ProjectCore")
                ));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ProjectCoreContext>()
                .AddDefaultTokenProviders();
            services.AddTransient<TaskRepository, TaskRepository>(); 
        }
       
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
//            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "login",
                    template: "{controller=Login}/{action=Index}");
                routes.MapRoute(
                    name: "register",
                    template: "{controller=Register}/{action=Index}");
                routes.MapRoute(
                    name: "add",
                    template: "{controller=Task}/{action=Add}");
                routes.MapRoute(
                    name: "edit",
                    template: "{controller=Task}/{action=Edit}/{id?}");
            });
        }
    }
}