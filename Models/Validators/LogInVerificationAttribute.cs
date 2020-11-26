using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS10_Project_Fisketorvet_V1.Models.Validators
{
    public class LogInVerificationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string[] attributes = value as string[];
            foreach(Customer c in Customer.Catalog.Values)
            {
                if (attributes[0] == c.Email && attributes[1] == c.Password) return true;
            }
            return false;
        }
    }
}
