using System.ComponentModel.DataAnnotations;

namespace Api_Disney.Validators
{
    public class DateInPastAttribute : ValidationAttribute
    {
        public DateInPastAttribute() : base("La fecha debe estar en el pasado.")
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime date && date > DateTime.Now)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
    

