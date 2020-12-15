using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS10_Project_Fisketorvet_V1.Pages.Customer
{
    public class CreateCustomerModel : PageModel
    {
        public static bool InvalidPasswords;
        public static string ReturnPage;
        [BindProperty]
        public Models.Customer Customer
        {
            get; set;
        }
        [BindProperty]
        [Required(ErrorMessage = "The password is required")]
        [MaxLength(20, ErrorMessage = "The password must be maximum 20 characters long")]
        [MinLength(6, ErrorMessage = "The password must be at least 6 characters long")]
        public string Password1
        {
            get; set;
        }
        [BindProperty]
        [Required(ErrorMessage = "Your need to confirm your password")]
        public string Password2
        {
            get; set;
        }
        public IActionResult OnGet(string returnpage)
        {
            if (returnpage!=null) ReturnPage = returnpage;
            InvalidPasswords = false;
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ReturnPage == null) ReturnPage = "/LoggedInUser/Login";
            if (Password1 != Password2) InvalidPasswords = true;
            else if (Password1 == Password2) InvalidPasswords = false;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (InvalidPasswords)
            {
                return Page();
            }
            PasswordHasher<Models.Customer> hasher = new PasswordHasher<Models.Customer>();
            Customer.Password = hasher.HashPassword(Customer, Password1);
            Models.Customer.Create(Customer);
            return RedirectToPage(ReturnPage);
        }
    }
}
