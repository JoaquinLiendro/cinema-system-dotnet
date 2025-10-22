using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;

namespace Reserva_C.Models
{

    public class Empleado : Persona 
    {

        //private static int proximoLegajo = 1;

        [Required(ErrorMessage = "{0} es requerido")]

        public int Legajo { get; set; } 

        



    }
}
