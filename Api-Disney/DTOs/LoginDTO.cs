using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Api_Disney.DTOs
{
    public class LoginDTO
    {
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
