using Backend.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositorios
{
    public class ReposotorioMemoria:IRepositorio
    {
        private List<Genero> _generos ;

        public ReposotorioMemoria()
        {
            _generos = new List<Genero>()
            {
                new Genero(){Id=1,Nombre="Terror"},
                new Genero(){Id=2,Nombre="Romance"},
                new Genero(){Id=2,Nombre="Drama"},
                new Genero(){Id=2,Nombre="Documentales"},
            };
        }
        public List<Genero> ObtenerTodosLosGeneros()
        {
            return _generos;
        }

    }
}
