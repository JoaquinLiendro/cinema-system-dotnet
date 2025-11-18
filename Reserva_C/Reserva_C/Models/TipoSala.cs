using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reserva_C.Models
{
    public class TipoSala
    {
        //- Nombre
        //- Precio
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} es requerido.")]
        [RegularExpression(@"[a-zA-Z áéíóú ÁÉÍÓÚ 0-9]*", ErrorMessage = "{0} solo admite caracteres alfanumericos.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "el {0} debe estar entre el {2} y el {1}")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "{0} es requerido.")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} debe ser un número positivo.")]
        public double Precio { get; set; }
        public List<Sala> SalaList { get; set; }
    }
}
