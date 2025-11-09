using System.ComponentModel.DataAnnotations;

namespace Reserva_C.Models.ViewModels
{
    public class RegistroUsuario
    {
        

        [Required(ErrorMessage = "{0} es requerido")]
        [EmailAddress(ErrorMessage = "Formato {0} inválido.")]
        [StringLength(30, ErrorMessage = "{0} debe contener menos de {1} caracteres")]
        public  string Email { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }


        [Required(ErrorMessage = "{0} es requerido")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmacion Contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña no coincide")]
        public string ConfirmacionPassword { get; set; }
    }
}
