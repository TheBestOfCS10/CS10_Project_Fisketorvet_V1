using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS10_Project_Fisketorvet_V1.Pages.ShoppingCart
{
    public class CheckoutModel : PageModel
    {
        public static bool InsuficientFunds = false;
        public static bool CompletedTransaction = false;
        [BindProperty]
        [Required(ErrorMessage ="The Zip code is required")]
        [Range(1000,9999)]
        public int ZIP
        {
            get; set;
        }
        [Required(ErrorMessage = "The street is required")]
        [BindProperty]
        [MaxLength(50)]
        public string Street
        {
            get;set;
        }
        [Required(ErrorMessage = "The street number is required")]
        [BindProperty]
        public string StreetNR
        {
            get; set;
        }
        public IActionResult OnGet()
        {
            InsuficientFunds = false;
            CompletedTransaction = false;
            return Page();
        }
        public IActionResult OnPost(double amount)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Models.Customer.Catalog[LoggedInUser.CurrentUser.User[0]].Account.CanPay(amount))
            {
                #region Payment
                Models.Customer.Catalog[LoggedInUser.CurrentUser.User[0]].Account.Pay(amount);
                #endregion
                #region Order creation
                Models.Order order = new Models.Order();
                order.Street = Street;
                order.StreetNR = StreetNR;
                order.ZIP = ZIP;
                order.Items = GetBasketItems(Models.Basket.GetBasket(Models.Customer.Catalog[LoggedInUser.CurrentUser.User[0]].BasketID).Items);
                order.OwnerID = LoggedInUser.CurrentUser.User[0];
                order.Price = CalculateTotalPrice(BasketModel.CalculateItemsTotalPrice(), 10);
                Models.Order.Create(order);
                #endregion
                #region Clearing the basket
                Models.Basket.GetBasket(Models.Customer.Catalog[LoggedInUser.CurrentUser.User[0]].BasketID).ClearBasket();
                #endregion
                CompletedTransaction = true;
                return Page();
            }
            else
            {
                InsuficientFunds = true;
                return Page();
            }
        }

        public static double CalculateTotalPrice(double price, double discount)
        {
            return price -= price * 0.01 * discount;
        }
        public static List<int[]> GetBasketItems (List<int[]> basket)
        {
            List<int[]> list = new List<int[]>();
            foreach(int[] i in basket)
            {
                list.Add(i);
            }
            return list;
        }
    }
}
