using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicsRate.Helpers;
using ClinicsRate.Interfaces;
using ClinicsRate.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicsRate
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
            RegisterDependencies(services);
            services.AddCors();
            services.AddMvc();

            // polaczenie do bazy danych 
            services.AddDbContext<ClinicRateDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("LocalConnectionDb"));
            });
        }

        private void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<IDictCityService, DictCityService>();
            services.AddScoped<IClinicService, ClinicService>();
            services.AddScoped<IDictCityService, DictCityService>();
            services.AddScoped<IOpinionService, OpinionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
