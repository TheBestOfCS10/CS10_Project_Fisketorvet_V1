using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS10_Project_Fisketorvet_V1.Pages.Administration.Order
{
    public class DeleteOrderModel : PageModel
    {
        static public int Order;
        public void OnGet(int id)
        {
            Order = id;
        }
        public IActionResult OnPost(bool delete)
        {
            if (delete)
            {
                Models.Order.Delete(Order);
                return RedirectToPage("/Administration/AdminOrders");
            }
            return RedirectToPage("/Administration/AdminOrders");
        }
    }
}
