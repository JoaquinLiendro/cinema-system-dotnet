using System.Collections.Generic;

namespace Reserva_C.Models
{
    public class Cliente : Persona 
    {
        //- UserName
        //- Nombre
        //- Apellido
        //- DNI
        //- Telefono
        //- Direccion
        //- FechaAlta
        //- Email
        //- Reservas

        public int Id { get; set; }

        public List<Reserva> Reservas { get; set; }
    }
}
