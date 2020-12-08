using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS10_Project_Fisketorvet_V1.Interfaces;
using CS10_Project_Fisketorvet_V1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CS10_Project_Fisketorvet_V1.Pages
{
    public class BasketModel : PageModel
    {
        private static BasketModel _instance;

        public static BasketModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BasketModel();
                }
                return _instance;
            }
        }
        [BindProperty]
        [Required(ErrorMessage = "You need to link a bank account to continue")]
        public string NoBankAccountChecker
        {
            get;set;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPostRemove(int p)
        {
            ShoppingCart.BasketHelper.RemoveFromBasket(p);
            return Page();
        }
        public IActionResult OnPostCheckout()
        {
            return RedirectToPage("/ShoppingCart/Checkout");
        }
        public IActionResult OnPostPlus(int p)
        {
            ShoppingCart.BasketHelper.AddToBasket(p, 1);
            return Page();
        }
        public IActionResult OnPostMinus(int p)
        {

            ShoppingCart.BasketHelper.AddToBasket(p, -1);
            return Page();
        }
        public IActionResult OnPostFail()
        {
            if (!ModelState.IsValid)
                return Page();
            return Page();
        }
        public static double CalculateItemsTotalPrice()
        {
            double subtotal = 0;
            foreach (int[] p in Basket.GetBasket(Models.Customer.Catalog[LoggedInUser.CurrentUser.User[0]].BasketID).Items)
            {
                subtotal = subtotal + (Models.Product.GetProduct(p[0], Models.Product.ProductCatalog).ProductPrice*p[1]);
            }
            return subtotal;
        }
        public static int CalculateItemsNr()
        {
            int total = 0;
            foreach (int[] p in Basket.GetBasket(Models.Customer.Catalog[LoggedInUser.CurrentUser.User[0]].BasketID).Items)
            {
                total = total + (1 * p[1]);
            }
            return total;
        }
    }
}
