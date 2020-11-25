using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS10_Project_Fisketorvet_V1.Models.Validators
{
    public class ConfirmPasswordAttribute : ValidationAttribute
    {
 
        public override bool IsValid(object value)
        {
            string[] passwords = value as string[];
            if (passwords[1]==passwords[2])
            {
                return true;
            }
            else return false;
        }
    }
}
