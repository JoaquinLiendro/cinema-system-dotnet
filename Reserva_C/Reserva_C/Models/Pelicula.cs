using Microsoft.AspNetCore.Http;
using Reserva_C.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reserva_C.Models
{
    public class Pelicula
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "el campo {0} es requerido")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "el {0} debe estar entre el {2} y el {1}")]
        public string Titulo { get; set; }
       
        [Required(ErrorMessage = "el campo {0} es requerido")]
        [StringLength(100, MinimumLength = 20, ErrorMessage = "el {0} debe estar entre el {2} y el {1}")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
        
        [Required(ErrorMessage = "el campo {0} es requerido")]
        [DataType(DataType.Date)]
        public DateOnly FechaLanzamiento { get; set; }

        //[Required(ErrorMessage = "El campo {0} es requerido")]
        [NotMapped] 
        public IFormFile FotoArchivo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Foto { get; set; } = Configs.FotoDef; 
        public List<Funcion> Funciones { get; set; }
        public Genero Genero { get; set; } 
        


    }
}
