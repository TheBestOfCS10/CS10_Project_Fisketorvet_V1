using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS10_Project_Fisketorvet_V1.Pages.Payment
{
    public class RemoveBankAccountModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPost(bool delete)
        {
            if (delete)
            {
                Models.BankAccount.Remove(LoggedInUser.CurrentUser.User);
                return RedirectToPage("/LoggedInUser/UserProfile");
            }
            else return RedirectToPage("/LoggedInUser/UserProfile");
        }
    }
}
