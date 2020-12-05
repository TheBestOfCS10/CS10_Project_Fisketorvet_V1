using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS10_Project_Fisketorvet_V1.Interfaces;
using CS10_Project_Fisketorvet_V1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


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

        public IActionResult OnGet()
        {
            return Page();
        }

        //public double CalculateItemsTotalPrice()
        //{
        //    double subtotal = 0;
        //    foreach (var item in BasketItems)
        //    {
        //        _ = subtotal + item.ProductPrice;
        //    }
        //    return subtotal;
        //}
    }
}
