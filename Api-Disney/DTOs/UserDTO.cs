using System.ComponentModel.DataAnnotations;

namespace Api_Disney.DTOs
{
    public class UserDTO
    {
        [Display(Name = "Nombre:")]
        [Required(ErrorMessage = "Por favor, ingresar el Nombre:")]
        [StringLength(150, MinimumLength = 4)]
        public string Nombre { get; set; } = string.Empty;

        [Display(Name = "Segundo Nombre:")]
        [Required(ErrorMessage = "Por favor, ingresar el Segundo Nombre:")]
        [StringLength(150, MinimumLength = 4)]
        public string segundoNombre { get; set; } = string.Empty;


        [Required(ErrorMessage = "Por favor, seleccionar una imagen.")]
        [Display(Name = "Imagen")]
        public string Imagen { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Email es requerido."), EmailAddress]
        [Display(Name = "Correo Electronico")]

        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; } = string.Empty;
    }
}
