﻿using Backend.Entidades;
using Backend.Repositorios;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Backend.Controller
{
    [Microsoft.AspNetCore.Mvc.Route("api/generos")]
    //con este controlo los validor
    [ApiController]
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
        //task= promesa
        public async Task<ActionResult<Genero>> Get(int id,[FromHeader] string nombre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var genero=await repositorio.ObtenerGeneroPorID(id);

            if (genero==null)
            {
                return NotFound(); 
            }
            return genero;
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
