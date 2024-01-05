using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AppVenta.Infraestructura.Datos.Contextos;


namespace AppVenta.Infraestructura.API
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
            services.AddDbContext<VentaContexto>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("csventa")));
            services.AddCors(options =>
            {
                options.AddPolicy(name: "frontend",
                                builder =>
                                {
                                    builder.WithOrigins("https://localhost:7174", "http://localhost:3000", "http://172.20.104.113:3000");
                                    builder.AllowAnyHeader();
                                    builder.AllowAnyMethod();
                                    builder.AllowAnyOrigin();
                                });
            });
            services.AddControllers();

            services.AddMvc();
        
            services.AddSwaggerGen();

            services.AddScoped<Appventadominio.Interfaces.Repositorios.IRepositorioBase<Appventadominio.Producto, Guid>, AppVenta.Infraestructura.Datos.Repositorios.ProductoRepositorio>();
            services.AddScoped<AppVenta.Aplicaciones.Interfaces.IServicioBase<Appventadominio.Producto, Guid>, AppVenta.Aplicaciones.Servicios.ProductoServicio>();
            services.AddScoped<Appventadominio.Interfaces.Repositorios.IRepositorioMovimiento<Appventadominio.Venta, Guid>,AppVenta.Infraestructura.Datos.Repositorios.VentaRepositorio>();
            services.AddScoped<AppVenta.Aplicaciones.Interfaces.IServicioMovimiento<Appventadominio.Venta, Guid>, AppVenta.Aplicaciones.Servicios.VentaServicios>();
            services.AddScoped<Appventadominio.Interfaces.Repositorios.IRepositorioDetalle<Appventadominio.VentaDetalle, Guid>, AppVenta.Infraestructura.Datos.Repositorios.VentaDetalleRepositorio>();
            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "App V1");
                });
            }

            app.UseCors("frontend");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
