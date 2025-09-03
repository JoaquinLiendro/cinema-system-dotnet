using System;

namespace Reserva_C.Models
{
    public class Persona
    {
//        - UserName
//        - Nombre
//        - Apellido
//        - DNI
//        - Telefono
//        - Direccion
//        - FechaAlta
//        - Email

        public int Id { get; set; }

        public string UserName { get; set; }    

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int DNI { get; set; }

        public int Telefono { get; set; } 

        public string Direccion {  get; set; }
        
        public DateTime FechaAlta { get; set; }

        public string Email { get; set; }
    }
}
