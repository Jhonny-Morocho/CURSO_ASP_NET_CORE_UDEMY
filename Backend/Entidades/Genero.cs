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
        [StringLength(maximumLength:10)]
        public string Nombre { get; set; }

        //otros ejemplos mas
        [Range(18,20)]
        public int Edad { get; set; }
        [CreditCard]
        public string TarjetaCredito { get; set; }
        [Url]
        public string URL { get; set; }


    }
}
