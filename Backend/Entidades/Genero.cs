using Backend.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entidades
{
    public class Genero:IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El campo {0} es requerido")]
        [StringLength(maximumLength:10)]
        //validacion por parametro 
        //[PrimeraLetraMayusculaAtribute]
        public string Nombre { get; set; }

        //otros ejemplos mas
        [Range(18,20)]
        public int Edad { get; set; }
        [CreditCard]
        public string TarjetaCredito { get; set; }
        [Url]
        public string URL { get; set; }

        //se creo al momneto de herado en IValidatableObject
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Nombre))
            {
                var primeraLetra = Nombre[0].ToString();
                if (primeraLetra!=primeraLetra.ToUpper())
                {
                    //el segundo parametro estoy especificnado a q paramtero le corresponde el error
                    yield return new ValidationResult("La primera letra debe ser mayuscula",
                        new string[] { nameof(Nombre)});
                }
            }
        }
    }
}
