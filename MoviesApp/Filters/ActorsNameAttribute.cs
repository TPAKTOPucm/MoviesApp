using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Filters {
    public class ActorsNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object name, ValidationContext validationContext)
        {
            if (((String)name).Length < 4)
            {
                return new ValidationResult("This parameter cannot be less tan 4 symbols");
            }
            return ValidationResult.Success;
        }
    }
}
