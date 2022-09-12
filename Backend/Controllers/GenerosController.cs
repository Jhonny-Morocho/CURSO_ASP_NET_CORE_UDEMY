using Backend.Entidades;
using Backend.Repositorios;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Backend.Controller
{
    [Microsoft.AspNetCore.Mvc.Route("api/generos")]
    public class GenerosController:ControllerBase
    {
        private readonly IRepositorio repositorio;

        public GenerosController(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }
        //creamos la accion
        [HttpGet("listado")]
        public ActionResult<List<Genero>> Get()
        {
            return repositorio.ObtenerTodosLosGeneros();
        }
        [HttpGet("{id:int}")]
        public ActionResult<Genero> Get(int id)
        {
            var genero= repositorio.ObtenerGeneroPorID(id);

            if (genero==null)
            {
                return NotFound();
            }
            return genero;
        }
        [HttpPost]
        public ActionResult Post()
        {
            return NoContent();
        }
        [HttpPut]
        public ActionResult Put()
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
