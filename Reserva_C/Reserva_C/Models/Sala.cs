using System.Collections.Generic;

namespace Reserva_C.Models
{
    public class Sala
    {
        //- Numero
        //- TipoSala
        //- CapacidadButacas
        //- Funciones
        public int Id { get; set; }
        public int Numero { get; set; }
        public TipoSala TipoSala { get; set; }
        public int CapacidadButacas { get; set; }
        public List<Funcion> Funciones { get; set; }
    }
}
