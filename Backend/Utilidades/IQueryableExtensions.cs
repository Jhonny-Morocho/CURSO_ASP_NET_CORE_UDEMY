using Backend.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Utilidades
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginar<T> (this IQueryable<T> queryable,PaginacionDTO paginacionDTO)
        {
        
            return queryable.Skip((paginacionDTO.Pagina -1) * paginacionDTO.RecordPorPagina).
                Take(paginacionDTO.RecordPorPagina);
        }
    }
}
