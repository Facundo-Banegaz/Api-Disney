using Api_Disney.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api_Disney.DTOs
{
    public class GenreDTO
    {


        [Display(Name = "Nombre Del Género:")]
        [Required(ErrorMessage = "Por favor, ingresar el Género:")]
        [StringLength(150, MinimumLength = 4)]
        public string Nombre { get; set; } = string.Empty;

    }
}
