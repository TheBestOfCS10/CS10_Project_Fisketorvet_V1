using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS10_Project_Fisketorvet_V1.Pages.LoggedInUser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS10_Project_Fisketorvet_V1.Pages.Customer
{
    public class DeleteCustomerModel : PageModel
    {
        public static string ReturnPage;
        [BindProperty]
        static Models.Customer Customer
        {
            get; set;
        }
        public IActionResult OnGet(int id, string returnpage)
        {
            if (returnpage != null) ReturnPage = returnpage;
            Customer = Models.Customer.Search(id);
            return Page();
        }
        public IActionResult OnPost(bool delete)
        {
            if (ReturnPage == null) ReturnPage = "/Index";
            if (delete)
            {
                if (Customer.ID == CurrentUser.User[0])
                {
                    CurrentUser.LogOut();
                }
                Models.Customer.Delete(Customer.ID);
                return RedirectToPage(ReturnPage);
            }
            return RedirectToPage(ReturnPage);
        }
    }
}
