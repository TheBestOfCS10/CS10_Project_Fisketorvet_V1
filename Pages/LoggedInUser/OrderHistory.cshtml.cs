using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS10_Project_Fisketorvet_V1.Pages.LoggedInUser
{
    public class OrderHistoryModel : PageModel
    {
        public void OnGet()
        {
        }
        public static string ListProducts(Models.Order order)
        {
            string message = "";
            int counter = 0;
            foreach(int[] i in order.Items)
            {
                message = message +  Models.Product.GetProduct(i[0], Models.Product.ProductCatalog).ProductName;
                counter++;
                if(counter < order.Items.Count)
                {
                    message = message + (i[1]<=1 ? ", " : $", {i[1]}x ");
                }
            }
            return message;
        }
    }
}
