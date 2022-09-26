using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTO
{
    public class PaginacionDTO
    {
        public int Pagina { get; set; }
        private int recordPorPagina = 10;
        private readonly int cantidadMaximaRecordsPorPagina = 50;
        public int RecordPorPagina
        {
            get 
            {
                return recordPorPagina; 
                    
            }
            set
            {
                recordPorPagina = (value > cantidadMaximaRecordsPorPagina) ? cantidadMaximaRecordsPorPagina : value;
            }
        }

    }
}
