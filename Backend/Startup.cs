using Backend.Filtros;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Nancy.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Backend
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


            // JwtBearerDefaults
            services.AddAuthentication(JwtBearerDefaults.Scheme).AddJwtBearer();

            //agregar un servicio
            //********* CICLO DE VIDA DE UN SERVICIO *****//

            //services.AddScoped<IRepositorio, ReposotorioMemoria>();//se envia la misma instancia

     

            //registrar un filtro personalizado de exepcion en mi app
            services.AddControllers(options=> {
                options.Filters.Add(typeof(FiltroExepcion));
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Backend", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
   
            if (env.IsDevelopment())
            {
                //definiendo milleword
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend v1"));
            }
            //tambien es un middleware
            // los q empiezan con use no detiene el proceso
            app.UseHttpsRedirection();

            app.UseRouting();
            //autenticacion
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
