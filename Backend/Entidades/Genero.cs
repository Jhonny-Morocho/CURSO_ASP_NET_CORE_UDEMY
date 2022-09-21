﻿using Backend.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entidades
{
    public class Genero
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El campo {0} es requerido")]
        [StringLength(maximumLength:50)]
        [PrimeraLetraMayusculaAtribute]
        public string Nombre { get; set; }

    }
}
