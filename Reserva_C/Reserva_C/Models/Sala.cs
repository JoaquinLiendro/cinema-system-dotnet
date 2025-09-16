using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reserva_C.Models
{
    public class Sala
    {
        //- Numero
        //- TipoSala
        //- CapacidadButacas
        //- Funciones
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} es requerido.")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} debe ser un número positivo.")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "{0} es requerido.")]
        [Range(50, int.MaxValue, ErrorMessage = "{0} debe ser un número positivo superior o igual a {1}.")]
        public int CapacidadButacas { get; set; }
        public TipoSala TipoSala { get; set; }
        public int TipoSalaId { get; set; }
        public List<Funcion> Funciones { get; set; }
    }
}
