using Api_Disney.Models;
using System.ComponentModel.DataAnnotations;

namespace Api_Disney.DTOs
{
    public class CharacterDTO
    {
        [Display(Name = "Nombre:")]
        [Required(ErrorMessage = "Por favor, ingresar el Nombre del Personaje:")]
        [StringLength(150, MinimumLength = 4)]
        public string Nombre { get; set; } = string.Empty;


        [Required(ErrorMessage = "Por favor, seleccionar una imagen.")]
        [Display(Name = "Imagen")]
        public string Imagen { get; set; } = string.Empty;

        [Display(Name = "Fecha Nacimiento:")]
        [Required(ErrorMessage = "Por favor, ingresar la Fecha:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Display(Name = "Peso:")]
        [Required(ErrorMessage = "Por favor, ingresar el peso.")]
        [Range(0, float.MaxValue, ErrorMessage = "El peso debe ser un valor positivo.")]

        public float Peso { get; set; }

        [Display(Name = "Historia:")]
        [Required(ErrorMessage = "Por favor, ingresar la Historia del Personaje:")]

        public string? Historia { get; set; }
    }
}
