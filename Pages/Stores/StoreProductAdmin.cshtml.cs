using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS10_Project_Fisketorvet_V1.Interfaces;
using CS10_Project_Fisketorvet_V1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS10_Project_Fisketorvet_V1.Pages.Stores
{
    public class StoreAdminModel : PageModel
    {
        IProductRepository products;
        IStores stores;

        public StoreAdminModel(IProductRepository prodRepo, IStores storeRepo)
        {
            products = prodRepo;
            stores = storeRepo;
        }

        public List<Product> Products { get; set; }

        [BindProperty(SupportsGet =true)]
        public int StoreId { get; set; }

        public Store Store { get; set; }

        public void OnGet(int storeId)
        {
            StoreId = storeId;
            Store = stores.AllStores()[StoreId];
            Products = products.GetStoreProducts(storeId);
        }

        public void OnPostDelete(int prodId)
        {
            products.DeleteProduct(prodId);
            OnGet(StoreId);
        }
    }
}
