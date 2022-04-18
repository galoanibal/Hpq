using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PRUEBA_QPH_WEB
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
            //Libreria para que se refresque el html en caliente 
            services.AddControllers().AddRazorRuntimeCompilation();
            services.AddHttpContextAccessor();
            services.AddMemoryCache();



            services.AddSession(options => {
                options.Cookie.Name = "Prueba_QPH_SE";
                options.Cookie.Path = "/";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromMinutes(60);
            });

            services
                .AddAuthentication("Identity.Application")
                .AddCookie("Identity.Application", options => {
                    options.Cookie.Name = "Prueba_QPH_AU";
                    options.Cookie.Path = "/";
                    options.SlidingExpiration = true;
                    options.LoginPath = new PathString("/Login");
                    options.LogoutPath = new PathString("/Login/Logout");
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                });

            services.AddAntiforgery(options => {
                options.Cookie.Name = "Prueba_QPH_AF";
                options.Cookie.Path = "/";
            });


            // Add framework services.
            services
                .AddControllersWithViews()
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);           
            services.AddRazorPages();
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
                app.UseExceptionHandler("/Error/500");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseStatusCodePagesWithReExecute("/Error/{0}");

            app.UseAuthentication();          

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}");
            });
        }
    }
}
