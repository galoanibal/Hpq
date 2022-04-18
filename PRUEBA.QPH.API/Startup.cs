using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PRUEBA.QPH.API.Conection;
using PRUEBA.QPH.API.Datos;
using PRUEBA.QPH.API.Interfaces;

namespace PRUEBA.QPH.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PRUEBA.QPH.API", Version = "v1" });
            });

            var connectionString = Configuration.GetConnectionString("ConecctionDbTest");
            services.AddDbContext<TestDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
           
            services.AddTransient<IClientes, DatosClientes>();
            services.AddTransient<ICuentas, DatosCuentas>();
            services.AddTransient<IMovimientos, DatosMovimientos>();
            services.AddTransient<ILogin, DatosLogin>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PRUEBA.QPH.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
