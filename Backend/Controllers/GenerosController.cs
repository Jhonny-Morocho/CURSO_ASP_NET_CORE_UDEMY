using Backend.Entidades;
using Backend.Filtros;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
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
    //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class GenerosController:ControllerBase
    {
        private readonly ILogger<GenerosController> logger;
        private readonly AplicationDbContext context;

        public GenerosController(ILogger<GenerosController> logger,AplicationDbContext context) 
        {
            this.logger = logger;
            this.context = context;
        }
        //creamos la accion
        [HttpGet]
        public async Task<ActionResult<List<Genero>>> Get()
        {
            return await context.Generos.ToListAsync();
        }
        [HttpGet("{id:int}")]
        //task= promesa
        public async Task<ActionResult<Genero>> Get(int id)
        {
            throw new NotImplementedException();
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
        public async Task<ActionResult> Post([FromBody] Genero genero)
        {
            context.Add(genero);
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut]
        public ActionResult Put([FromBody] Genero genero)
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        public ActionResult Delete()
        {
            throw new NotImplementedException();
        }
    }
}
