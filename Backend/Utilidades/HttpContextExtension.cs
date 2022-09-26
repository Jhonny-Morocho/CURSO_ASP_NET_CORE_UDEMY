using Backend.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Utilidades
{
    public static class HttpContextExtension
    {

        //insertamos en la cabezera del http la informacion
        public async static Task InsertarParametrosPaginacionEnCabezera<T>(this HttpContext httpContex,
                                                                           IQueryable<T> queryable){
            if (httpContex == null) { throw new ArgumentException(nameof(httpContex)); }
            double cantidad = await queryable.CountAsync();
            httpContex.Response.Headers.Add("cantidadTotalRegistros",cantidad.ToString());
        }


        //internal static Task InsertarParametrosPaginacionEnCabezera(IQueryable<Genero> queryable)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
