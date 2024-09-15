using System.ComponentModel.DataAnnotations;

namespace Api_Disney.Validators
{
    public class DateNotInFutureAttribute : ValidationAttribute
    {
        public DateNotInFutureAttribute() : base("La fecha no puede ser una fecha futura.")
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

