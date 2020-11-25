using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS10_Project_Fisketorvet_V1.Models.Validators
{
    public class EmailValidationAttribute : ValidationAttribute
    {
        bool _inverted;
        public EmailValidationAttribute(bool inverted)
        {
            _inverted = inverted;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string email = value as string;
            if (!_inverted)
            {
                foreach (Customer c in Customer.Catalog.Values)
                {
                    if (c.Email == email) return new ValidationResult("This email adress is already taken.");
                }
                return ValidationResult.Success;
            }
            else
            {
                foreach (Customer c in Customer.Catalog.Values)
                {
                    if (c.Email == email) return ValidationResult.Success;
                }
                return new ValidationResult("This email adress does not belong to any account.");
            }
        }
    }
}
