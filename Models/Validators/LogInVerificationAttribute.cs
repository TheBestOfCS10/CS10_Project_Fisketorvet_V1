using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CS10_Project_Fisketorvet_V1.Models.Validators
{
    public class LogInVerificationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            PasswordHasher<Customer> hasher = new PasswordHasher<Customer>();
            string[] attributes = value as string[];
            
            foreach(Customer c in Customer.Catalog.Values)
            {
                if (attributes[0] == c.Email)
                {
                    string hashedPassword = c.Password;
                    PasswordVerificationResult result =  hasher.VerifyHashedPassword(c, hashedPassword, attributes[1]);
                    if (result == PasswordVerificationResult.Success) return true;
                }
            }
            foreach (Admin c in Admin.AdminCatalog.Values)
            {
                if (attributes[0] == c.Email)
                {
                    if (attributes[0] == c.Email)
                    {
                        string hashedPassword = c.Password;
                        hasher.VerifyHashedPassword(c, hashedPassword, attributes[1]);
                        PasswordVerificationResult result = hasher.VerifyHashedPassword(c, hashedPassword, attributes[1]);
                        if (result == PasswordVerificationResult.Success) return true;
                    }
                }
            }
            return false;
        }
    }
}
