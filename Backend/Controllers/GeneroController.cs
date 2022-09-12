using Backend.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    public class GeneroController
    {
        private readonly IRepositorio repositorio;

        public GeneroController(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }
    }
}
