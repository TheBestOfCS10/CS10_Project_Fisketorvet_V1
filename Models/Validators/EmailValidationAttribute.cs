using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS10_Project_Fisketorvet_V1.Models.Validators
{
    public class EmailValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string email = value as string;
            foreach (Customer c in Customer.Catalog.Values)
            {
                if (c.Email == email) return false;
            }
            return true;
        }
    }
}
