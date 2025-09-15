using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reserva_C.Models
{
    public class Pelicula
    {
        //        - Titulo
        //- Descripcion
        //- FechaLanzamiento
        //- Foto
        //- Funciones
        //- Genero(enum)

        public int Id { get; set; }
        [Required (ErrorMessage = "el campo {0} es requerido")]
        [RegularExpression(@"[a-zA-Z áéíóú]*", ErrorMessage = "solo se admiten caracteres alfabeticos")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "el {0} debe estar entre el {2} y el {1}")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "el campo {0} es requerido")]
        [RegularExpression(@"[a-zA-Z áéíóú]*", ErrorMessage = "solo se admiten caracteres alfabeticos")]
        [StringLength(100, MinimumLength = 20, ErrorMessage = "el {0} debe estar entre el {2} y el {1}")]
        public string Desc { get; set; }
        [Required(ErrorMessage = "el campo {0} es requerido")]
        public DateOnly FechaLanzamiento { get; set; }
        [Required(ErrorMessage = "el campo {0} es requerido")]
        public string Foto { get; set; }
        public List<Funcion> Funciones { get; set; }
        public Genero Genero { get; set; }


    }
}
