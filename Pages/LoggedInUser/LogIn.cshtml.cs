using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS10_Project_Fisketorvet_V1.Pages.LoggedInUser
{
    public class LogInModel : PageModel
    {
        string[] currentuser = new string[2];
        [Models.Validators.LogInVerification(ErrorMessage ="The email or password is wrong")]
        [BindProperty]
        public string[] CurrentUser
        {
            get { return currentuser; }
            set { currentuser = value; }
        }
        [BindProperty]
        public bool RemainLoggedIn
        {
            get;set;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            Models.Customer NewUser = new Models.Customer();
            NewUser.Email = CurrentUser[0];
            NewUser.Password = CurrentUser[1];
            LoggedInUser.CurrentUser.ChangeUser(NewUser, RemainLoggedIn);
            //foreach (Models.Admin a in Models.Admin.AdminCatalog.Values)
            //{
            //    if (a.Email == CurrentUser[0]) return RedirectToPage("/AdminHomepage");
            //}
            return RedirectToPage("/Index");
        }
    }
}
