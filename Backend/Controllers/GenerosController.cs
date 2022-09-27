using AutoMapper;
using Backend.DTO;
using Backend.Entidades;
using Backend.Filtros;
using Backend.Utilidades;
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
        private readonly IMapper mapper;

        public GenerosController(ILogger<GenerosController> logger,
                                AplicationDbContext context,
                                IMapper mapper) 
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }
        //creamos la accion
        [HttpGet]
        public async Task<ActionResult<List<GeneroDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            try {
                var queryable=  context.Generos.AsQueryable();
                await HttpContext.InsertarParametrosPaginacionEnCabezera(queryable);
                var generos =await queryable.OrderBy(x=>x.Nombre).Paginar(paginacionDTO).ToListAsync();
                return mapper.Map<List<GeneroDTO>>(generos);
            }
            catch (Exception e)
            {

                throw new ApplicationException($"ERROR EN EL CONTROLADOR GENERO "+e.Message);
                logger.LogWarning("LOG EN EL CONTROLADOR");
                return NotFound();
            }
        }
        [HttpGet("{id:int}")]
        //task= promesa
        public async Task<ActionResult<GeneroDTO>> Get(int id)
        {
            var genero =await context.Generos.FirstOrDefaultAsync(x=>x.Id==id);
            if (genero==null)
            {
                //http 404
                return NotFound();
            }
            return mapper.Map<GeneroDTO>(genero);
        }

  

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            var genero = mapper.Map<Genero>(generoCreacionDTO);
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
