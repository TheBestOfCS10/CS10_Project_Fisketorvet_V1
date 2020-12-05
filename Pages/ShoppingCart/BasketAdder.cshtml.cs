using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS10_Project_Fisketorvet_V1.Pages.ShoppingCart
{
    public class BasketAdderModel : PageModel
    {
        public IActionResult OnGet(Models.Product p, int storeId)
        {
            ShoppingCart.BasketHelper.AddToBasket(p.ProductId, 1);
            return RedirectToPage("/Stores/ShowStore", storeId);
        }
    }
}
