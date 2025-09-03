using System;
using System.Collections.Generic;
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

         public DateTime Fecha { get; set; }
         public TimeSpan Hora { get; set; }
         public string Descripcion { get; set; }
         public int ButacasDisponibles { get; set; }
         public bool Confimrada { get; set; }
         public Pelicula Pelicula { get; set; }
         public List<Reserva> Reservas { get; set; }
         public Sala Sala { get; set; }
         
    }
}
