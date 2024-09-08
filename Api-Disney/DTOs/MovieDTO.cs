using System.ComponentModel.DataAnnotations;
namespace Api_Disney.DTOs
{
    public class MovieDTO
    {
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
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Display(Name = "Nombre Del Género:")]
        [Required(ErrorMessage = "Por favor, ingresar el Género:")]

        public int GeneroId  { get; set; }

        [Display(Name = "Califiacíon:")]
        [Required(ErrorMessage = "Por favor, ingresar la Califiacíon de la Película:")]
        [Range(1, 5, ErrorMessage = "El valor para {0} debe estar entre {1} y {5}.")]
        public int Calification { get; set; }
    }
}
