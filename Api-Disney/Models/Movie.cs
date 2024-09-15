using Api_Disney.DTOs;
using Api_Disney.Validators;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api_Disney.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Título:")]
        [Required(ErrorMessage = "Por favor, ingresar el Título de la Película:")]
        [StringLength(150, MinimumLength = 4)]
        public string Titulo { get; set; } = string.Empty;


        [Required(ErrorMessage = "Por favor, seleccionar una Imagen.")]
        [Display(Name = "Imagen")]
        public string Imagen { get; set; } = string.Empty;

        [Display(Name = "Fecha:")]
        [Required(ErrorMessage = "Por favor, ingresar la Fecha:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        [DateNotInFuture]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;


        [Display(Name = "Género:")]
        [Required(ErrorMessage = "Por favor, ingresar el Género:")]
        [StringLength(150, MinimumLength = 3)]
        public Genre? Genero {  get; set; }

        [JsonIgnore]
        public int GeneroId { get; set; }

        [Display(Name = "Califiacíon:")]
        [Required(ErrorMessage = "Por favor, ingresar la Califiacíon de la Película:")]
        [Range(1, 5, ErrorMessage = "El valor para {0} debe estar entre {1} y {5}.")]
        public int Calification { get; set; }

        //[JsonIgnore]
        public ICollection<Character>? Characters { get; set; }

    }
}
