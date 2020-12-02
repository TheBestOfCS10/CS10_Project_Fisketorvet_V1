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
    public class EditProductModel : PageModel
    {
        IProductRepository products;

        public EditProductModel(IProductRepository prodRepo)
        {
            products = prodRepo;
        }

        [BindProperty]
        public Product Product { get; set; }

        public void OnGet(int prodId)
        {
            Product = products.GetProduct(prodId);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                products.UpdateProduct(Product);
                return RedirectToPage($"ShowStore/{Product.StoreID}");
            }
            return Page();
        }
    }
}
