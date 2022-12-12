using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Filters {
    public class ActorsNameAttribute : ValidationAttribute {
        public string Name { get; }
        public ActorsNameAttribute(string name) {
            Name = name;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {

            if (Name.Length < 4) {
                return new ValidationResult("This parameter cannot be less tan 4 symbols");
            }

            return ValidationResult.Success;
        }
    }
}
