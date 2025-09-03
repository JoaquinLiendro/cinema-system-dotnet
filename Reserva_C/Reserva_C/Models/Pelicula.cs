using System;
using System.Collections.Generic;

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

        public int IdPelicula { get; set; }
        public string Titulo { get; set; }
        public string Desc { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public string Foto { get; set; }
        public List<Funcion> Funciones { get; set; }
        public Genero Genero { get; set; }


    }
}
