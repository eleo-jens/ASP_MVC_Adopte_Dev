using Common.Repositories;
using DO = DAL.Entities;
using DS = DAL.Services;
using BO = BLL.Entities;
using BS = BLL.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Handlers;

namespace MVC
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
            services.AddControllersWithViews();

            #region Ajout des injections de dépendances des services
            services.AddScoped<IDeveloperRepository<DO.Developer, int>, DS.DeveloperService>();
            services.AddScoped<IDeveloperRepository<BO.Developer, int>, BS.DeveloperService>();

            services.AddScoped<IITLangRepository<DO.ITLang, int>, DS.ITLangService>();
            services.AddScoped<IITLangRepository<BO.ITLang, int>, BS.ITLangService>();

            services.AddScoped<IDevLangRepository<DO.DevLang, int>, DS.DevLangService>();
            services.AddScoped<IDevLangRepository<BO.DevLang, int>, BS.DevLangService>();

            services.AddScoped<ICategoriesRepository<DO.Categories, int>, DS.CategoriesService>();
            services.AddScoped<ICategoriesRepository<BO.Categories, int>, BS.CategoriesService>();

            services.AddScoped<IClientRepository<DO.Client, int>, DS.ClientService>();
            services.AddScoped<IClientRepository<BO.Client, int>, BS.ClientService>();

            services.AddScoped<SessionManager>();
            #endregion

            #region Création du Cookie de session
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = "AdopteUnDev.Session";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromMinutes(50);
            });
            services.Configure<CookiePolicyOptions>(options =>
           {
               options.CheckConsentNeeded = context => true;
               options.MinimumSameSitePolicy = SameSiteMode.None;
           });
            #endregion

            #region Service d'accessibilité du HTTPCONTEXT par injection de dépendance
            services.AddHttpContextAccessor(); 
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseSession();
            app.UseCookiePolicy();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "login",
                //    pattern: "", 
                //    defaults: new { controller = "Auth", action = "Login" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
