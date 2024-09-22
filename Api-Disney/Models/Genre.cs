using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api_Disney.Models
{
    public class Genre
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nombre Del Género:")]
        [Required(ErrorMessage = "Por favor, ingresar el Género:")]
        [StringLength(150, MinimumLength = 4)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Por favor, seleccionar una Imagen.")]
        [Display(Name = "Imagen")]
        public string Imagen { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Movie>? Movies { get; set; }
    }
}
