using System.ComponentModel.DataAnnotations;

namespace Reserva_C.Models
{

    public class Empleado : Persona 
    {

        [Required(ErrorMessage = "{0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} debe ser un número positivo.")]
        public int Legajo { get; set; } 




    }
}
