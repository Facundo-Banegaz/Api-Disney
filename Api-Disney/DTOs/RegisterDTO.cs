using Api_Disney.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Api_Disney.DTOs
{
    [Index(nameof(Email), IsUnique = true)]
    public class RegisterDTO
    {

        [Display(Name = "Nombre:")]
        [Required(ErrorMessage = "Por favor, ingresar el Nombre:")]
        [StringLength(150, MinimumLength = 4)]
        public string Nombre { get; set; } = string.Empty;


        [Display(Name = "Apellido:")]
        [StringLength(150, MinimumLength = 4)]
        public string Apellido { get; set; } = string.Empty;





        [Required(ErrorMessage = "El Email es requerido.")]
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido")]
        [Display(Name = "Correo Electrónico")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "La longitud debe estar entre 5 y 100 caracteres")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [Display(Name = "Password"), PasswordPropertyText]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "La longitud debe estar entre 5 y 100 caracteres")]
        public string Password { get; set; } = string.Empty;
    }
}
