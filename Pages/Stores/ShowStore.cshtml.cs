using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CS10_Project_Fisketorvet_V1.Interfaces;
using CS10_Project_Fisketorvet_V1.Models;
using CS10_Project_Fisketorvet_V1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS10_Project_Fisketorvet_V1.Pages.Stores
{
    public class ShowStoreModel : PageModel
    {
        IProductRepository products;
        IStores stores;
        [BindProperty]
        [Required(ErrorMessage = "You must be logged in to add to the basket")]
        public int NonExistentUser
        {
            get;set;
        }
        static int storeid;
        public static int checkedproductid;
        public Store Store { get; set; }
        public List<Product> Products { get; set; }

        public ShowStoreModel(IStores storesRepo, IProductRepository productsRepo)
        {
            stores = storesRepo;
            products = productsRepo;
        }

        public IActionResult OnGet(int storeId)
        {
            Store = stores.AllStores()[storeId];
            Products = products.GetStoreProducts(storeId);
            storeid = storeId;
            return Page();
        }
        public IActionResult OnPost(int p)
        {
            if (!ModelState.IsValid)
            {
                Store = stores.AllStores()[storeid];
                Products = products.GetStoreProducts(storeid);
                checkedproductid = p;
                return Page();
            }
            return Page();
        }
        public IActionResult OnPostAdd(int p)
        {
            Store = stores.AllStores()[storeid];
            Products = products.GetStoreProducts(storeid);
            ShoppingCart.BasketHelper.AddToBasket(p, 1);
            return Page();
        }
    }
}
