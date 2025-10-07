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


        public int Id { get; set; }
        [Required(ErrorMessage = "el campo {0} es requerido")]
        [DataType(DataType.Date)]
        public DateOnly Fecha { get; set; }
        [Required(ErrorMessage = "el campo {0} es requerido")]
        [DataType(DataType.Time)]
        public TimeOnly Hora { get; set; }
        [Required(ErrorMessage = "el campo {0} es requerido")]
        [RegularExpression(@"[a-zA-Z áéíóú 0-9]*", ErrorMessage = "{0} solo admite caracteres alfabeticos y numericos.")]
        [StringLength(100, MinimumLength = 20, ErrorMessage = "el {0} debe estar entre el {2} y el {1}")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
        public int ButacasDisponibles { get; set; }
        [Required(ErrorMessage = "el campo {0} es requerido")]
        public bool Confimrada { get; set; }
        public Pelicula Pelicula { get; set; }
        public List<Reserva> Reservas { get; set; }
        public Sala Sala { get; set; }
        [Required(ErrorMessage = "el campo {0} es requerido")]
        public int SalaId { get; set; }
        [Required(ErrorMessage = "el campo {0} es requerido")]
        public int PeliculaId { get; set; }


    }
}
