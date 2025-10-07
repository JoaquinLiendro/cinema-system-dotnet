using System.ComponentModel.DataAnnotations;

namespace Reserva_C.Models
{
    public enum Genero
    {
        [Display(Name = "Terror")]
        Terror,
        [Display(Name = "Comedia")]
        Comedia,
        [Display(Name = "Tragedia")]
        Tragedia,
        [Display(Name = "Accion")]
        Accion,
        [Display(Name = "Romance")]
        Romance,
        [Display(Name = "Misterio")]
        Misterio,
        [Display(Name = "CineCatastrofe")]
        CineCatastrofe
    }
}
