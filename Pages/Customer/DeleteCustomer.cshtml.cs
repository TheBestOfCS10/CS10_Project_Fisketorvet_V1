using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS10_Project_Fisketorvet_V1.Pages.Customer
{
    public class DeleteCustomerModel : PageModel
    {
        [BindProperty]
        static Models.Customer Customer
        {
            get;set;
        }
        public IActionResult OnGet(int id)
        {
            Customer = Models.Customer.Search(id);
            return Page();
        }
        public IActionResult OnPost(bool delete)
        {
            if (delete)
            {
                if (Customer.ID == Shared.CurrentUser.User)
                {
                    Shared.CurrentUser.LogOut();
                }
                Models.Customer.Delete(Customer.ID);
                return RedirectToPage("/Index");
            }
            return RedirectToPage("/Index");
        }
    }
}
