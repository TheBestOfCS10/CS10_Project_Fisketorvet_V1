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
    public class DeleteProductModel : PageModel
    {
        IProductRepository products;

        public DeleteProductModel(IProductRepository prodRepo)
        {
            products = prodRepo;
        }

        [BindProperty]
        public Product Product { get; set; }

        [BindProperty]
        public int StoreId { get; set; }

        public void OnGet(int prodId, int storeId)
        {
            Product = products.GetProduct(prodId);
            StoreId = storeId;
        }

        public IActionResult OnPost()
        {
            products.DeleteProduct(Product.ProductId);
            return Redirect($"/Stores/StoreProductAdmin/{StoreId}");
        }
    }
}
