using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS10_Project_Fisketorvet_V1.Pages.Administration
{
    public class AdminCustomersModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
