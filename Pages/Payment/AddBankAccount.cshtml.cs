using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CS10_Project_Fisketorvet_V1.Models;

namespace CS10_Project_Fisketorvet_V1.Pages.Payment
{
    public class AddBankAccountModel : PageModel
    {
        [BindProperty]
        public BankAccount BankAccount
        {
            get; set;
        }
        public static string returnPage;
        public void OnGet(string returnpage)
        {
            returnPage = returnpage;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            BankAccount.Add(BankAccount, LoggedInUser.CurrentUser.User);
            return RedirectToPage(returnPage);
        }
    }
}
