using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Reserva_C.Models
{
    public class Persona : IdentityUser<int>
    {
        
        //public int Id { get; set; }

        /*[Required(ErrorMessage = "{0} es requerido")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{0} debe tener entre {2} y {1} caracteres")]
        [Display(Name="Nombre de usuario")]
        public string UserName { get; set; }*/

        [Required(ErrorMessage = "{0} es requerido")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "{0} solo puede contener letras.")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "{0} debe tener entre {2} y {1} caracteres.")]

        public string Nombre { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "{0} solo puede contener letras.")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "{0} debe tener entre {2} y {1} caracteres.")]
        public string Apellido { get; set; }

        [StringLength(8, MinimumLength = 6, ErrorMessage = "{0} debe tener entre {2} y {1} caracteres")]
        [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo puede contener numeros.")]
        public string DNI { get; set; }

        [RegularExpression(@"^\d{7,15}$", ErrorMessage = "{0} debe contener solo números y tener entre 7 y 15 dígitos.")]
        public string Telefono { get; set; }

        [StringLength(100, ErrorMessage = "{0} debe tener menos de {1} caracteres")]
        public string Direccion {  get; set; }
        
        public DateTime FechaAlta { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "{0} es requerido")]
        [EmailAddress(ErrorMessage = "Formato {0} inválido.")]
        [StringLength(30, ErrorMessage = "{0} debe contener menos de {1} caracteres")]
        public override string Email
        {
            get { return base.Email; }
            set { base.Email = value; }
        }
    }
}
