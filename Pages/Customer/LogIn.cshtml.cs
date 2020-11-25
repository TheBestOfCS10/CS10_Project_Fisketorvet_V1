using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS10_Project_Fisketorvet_V1.Pages.Customer
{
    public class LogInModel : PageModel
    {
        [BindProperty]
        public Models.Customer Customer
        {
            get;set;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if(Models.Customer.VerifyUser(Customer))
            {
                //current user = Catalog value
            }
            return Page();
        }
    }
}
