using System;
using System.ComponentModel.DataAnnotations;

namespace Reserva_C.Models
{
    public class Reserva
    {
        //        - Activa(flag)
        //        - CantidadButacas
        //        - Cliente
        //        - FechaAlta
        //        - Funcion

        public int IdReserva { get; set; }
        [Required(ErrorMessage = "el campo {0} es requerido")]
        public bool Activa { get; set; }
        [Required(ErrorMessage = "el campo {0} es requerido")]
        [Range(50, 100, ErrorMessage = "las {0} tienen que ser entre {1} y {2}")]
        public int CantButacas { get; set; }
        public Cliente Cliente { get; set; }
        [Required(ErrorMessage = "el campo {0} es requerido")]
        public DateOnly FechaAlta { get; set; }
        public Funcion Funcion { get; set; }
        

       
        
        

        //Propiedades Relacionales

        public int ClienteId { get; set; }
        public int IdFuncion { get; set; }

    }
}
