using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Clinic.DAL;
using Microsoft.EntityFrameworkCore;
using ClinicYo.Authorization;
using System;
using Microsoft.Extensions.Options;
using Clinic.DAL.Concrete;

namespace ClinicYo
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = new TimeSpan(12, 0, 0);
                options.CookieName = ".Cokie.Session";                
            });

            //ConnectionStrings
            services.AddSingleton<IConfiguration>(sp => Configuration);
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            
            //Add Db services
            var connection = services.BuildServiceProvider().GetService<IOptions<ConnectionStrings>>().Value.ClinicDb;
            services.AddDbContext<ClinicDbContext>(options => {
                options.UseSqlite(connection); });
            services.AddScoped(typeof(EFClinicDbRepository<>));
            services.AddScoped(typeof(EFGenericRepository<,>));
            services.AddScoped<UserRepository>();
            services.AddScoped<AccessRightsRepository>();
            services.AddScoped<ConsultationsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseSession();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "api",
                    template: "api/{controller}/{action}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
