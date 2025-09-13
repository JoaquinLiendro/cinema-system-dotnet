using System.Collections.Generic;

namespace Reserva_C.Models
{
    public class Cliente : Persona 
    {
        
        

        public List<Reserva> Reservas { get; set; }
    }
}
