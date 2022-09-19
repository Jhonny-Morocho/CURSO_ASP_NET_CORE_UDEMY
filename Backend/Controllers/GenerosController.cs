using Backend.Entidades;
using Backend.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Backend.Controller
{
    [Microsoft.AspNetCore.Mvc.Route("api/generos")]
    //con este controlo los validor
    [ApiController]
    //filtro de autenticacion
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class GenerosController:ControllerBase
    {
        private readonly IRepositorio repositorio;
        private readonly ILogger<GenerosController> logger;

        public GenerosController(IRepositorio repositorio,ILogger<GenerosController> logger)
        {
            this.repositorio = repositorio;
            this.logger = logger;
        }
        //creamos la accion
        [HttpGet("listado")]
        //aqui estot colocando un filtro
        //[ResponseCache(Duration =60)]
        
        public ActionResult<List<Genero>> Get()
        {
            logger.LogInformation("VAMOS A MOSTRAR LOS GENEROS");
            return repositorio.ObtenerTodosLosGeneros();
        }
        [HttpGet("{id:int}")]
        //task= promesa
        public async Task<ActionResult<Genero>> Get(int id,[FromHeader] string nombre)
        {
            logger.LogDebug("obteniendo un genero por id "+id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var genero=await repositorio.ObtenerGeneroPorID(id);

            if (genero==null)
            {
                logger.LogWarning("NO PUDIMOS ECONTRAR EL GENERO DE ID "+id);
                return NotFound(); 
            }
            return genero;
        }
        [HttpGet("guid")]
        //task= promesa
        public ActionResult<Guid> GetGUID()
        {
        
            return repositorio.obtenerGUI();
        }
        //public async Task<ActionResult<Genero>> Get(int id, [BindRequired] string nombre)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var genero = await repositorio.ObtenerGeneroPorID(id);

        //    if (genero == null)
        //    {
        //        return NotFound();
        //    }
        //    return genero;
        //}


        [HttpPost]
        public ActionResult Post([FromBody] Genero genero)
        {
            return NoContent();
        }
        [HttpPut]
        public ActionResult Put([FromBody] Genero genero)
        {
            return NoContent();
        }
        [HttpDelete]
        public ActionResult Delete()
        {
            return NoContent();
        }
    }
}
