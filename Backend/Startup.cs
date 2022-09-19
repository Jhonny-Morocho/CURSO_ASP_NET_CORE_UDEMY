using Backend.Repositorios;
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
            //agregar un servicio
            //********* CICLO DE VIDA DE UN SERVICIO *****//

            //services.AddScoped<IRepositorio, ReposotorioMemoria>();//se envia la misma instancia

            services.AddScoped<IRepositorio,ReposotorioMemoria>();//difentes intancias para cada peticion
            //end servicio

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Backend", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILogger<Startup> logger)
        {
            //solo para probar
            //app.Run(async context=> {
            //    await context.Response.WriteAsync("Estoy interceptando el pipiline");
            //});

            //ejecuta esta linena y sigue la siguiente no la para
            app.Use(async (contex,next)=> {
                using (var swapStream=new MemoryStream())
                {
                    var respuestaOriginal = contex.Response.Body;
                    contex.Response.Body = swapStream;
                    await next.Invoke();

                    swapStream.Seek(0, SeekOrigin.Begin);
                    string respuesta = new StreamReader(swapStream).ReadToEnd();
                    swapStream.Seek(0,SeekOrigin.Begin);

                    await swapStream.CopyToAsync(respuestaOriginal);
                    contex.Response.Body = respuestaOriginal;


                    logger.LogInformation(respuesta);


                }
            });

            app.Map("/map1",(app)=> {
                app.Run(async context=>
                {
                    await context.Response.WriteAsync("Estoy incertando el pipeline"); 
                });
            });


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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
