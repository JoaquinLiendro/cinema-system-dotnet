using Microsoft.EntityFrameworkCore;
using Reserva_C.Data;
using Reserva_C.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;

namespace Reserva_C.Models
{

    public class Empleado : Persona 
    {
       
        public int Legajo { get; set; } 

        



    }
}
