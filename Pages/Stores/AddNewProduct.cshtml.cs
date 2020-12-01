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
    public class AddNewProductModel : PageModel
    {
        IProductRepository products;

        public AddNewProductModel(IProductRepository prodRepo)
        {
            products = prodRepo;
        }

        [BindProperty]
        public Product NewProduct { get; set; }

        public IActionResult OnGet(int storeId)
        {
            NewProduct = new Product() { StoreID = storeId };
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                products.AddNewProduct(NewProduct);
                return RedirectToPage("Stores");
            }
            return Page();

        }
    }
}
