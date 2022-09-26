using AutoMapper;
using Backend.DTO;
using Backend.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Genero, GeneroDTO>();
            CreateMap<GeneroCreacionDTO, Genero>();
        }
    }
}
