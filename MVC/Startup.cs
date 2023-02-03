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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            services.AddScoped<IDeveloperRepository<DO.Developer, int>, DS.DeveloperService>();
            services.AddScoped<IDeveloperRepository<BO.Developer, int>, BS.DeveloperService>();

            services.AddScoped<IITLangRepository<DO.ITLang, int>, DS.ITLangService>();
            services.AddScoped<IITLangRepository<BO.ITLang, int>, BS.ITLangService>();

            services.AddScoped<IDevLangRepository<DO.DevLang, int>, DS.DevLangService>();
            services.AddScoped<IDevLangRepository<BO.DevLang, int>, BS.DevLangService>();
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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
