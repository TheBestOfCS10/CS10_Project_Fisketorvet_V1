using System;
using System.Collections.Generic;
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

            return Page();
        }
    }
}
