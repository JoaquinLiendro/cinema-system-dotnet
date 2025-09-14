using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Reserva_C.Models
{
    public class Funcion
    {
        //- Fecha
        //- Hora
        //- Descripcion
        //- ButacasDisponibles(Dato calculado)
        //- Confirmada
        //- Pelicula
        //- Reservas
        //- Sala


        public int IdFuncion { get; set; }
        [Required(ErrorMessage = "el campo {0} es requerido")]
        public DateOnly Fecha { get; set; }
        [Required(ErrorMessage = "el campo {0} es requerido")]
        public TimeOnly Hora { get; set; }
        [Required(ErrorMessage = "el campo {0} es requerido")]
        [RegularExpression(@"[a-zA-Z áéíóú]*", ErrorMessage = "solo se admiten caracteres alfabeticos")]
        [StringLength(100, MinimumLength = 20, ErrorMessage = "el {0} debe estar entre el {2} y el {1}")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "el campo {0} es requerido")]
        [Range(50, 100, ErrorMessage = "las {0} tienen que ser entre {1} y {2}")]
        public int ButacasDisponibles { get; set; }
        [Required(ErrorMessage = "el campo {0} es requerido")]
        public bool Confimrada { get; set; }
        public Pelicula Pelicula { get; set; }
        public List<Reserva> Reservas { get; set; }
        public Sala Sala { get; set; }
        public int IdSala { get; set; }
        public int IdPelicula { get; set; }


    }
}
