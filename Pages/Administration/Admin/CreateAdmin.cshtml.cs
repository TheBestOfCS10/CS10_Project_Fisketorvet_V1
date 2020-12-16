using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS10_Project_Fisketorvet_V1.Pages.Administration.Admin
{
    public class CreateAdminModel : PageModel
    {
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
        [BindProperty]
        public Models.Admin Admin
        {
            get;set;
        }
        public static bool InvalidPasswords = false;
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
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
            PasswordHasher<Models.Admin> hasher = new PasswordHasher<Models.Admin>();
            Admin.Password = hasher.HashPassword(Admin, Password1);
            Models.Admin.Create(Admin);
            return RedirectToPage("");
        }
    }
}
