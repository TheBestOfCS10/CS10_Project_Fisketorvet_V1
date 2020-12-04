using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS10_Project_Fisketorvet_V1.Interfaces;
using CS10_Project_Fisketorvet_V1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace CS10_Project_Fisketorvet_V1.Pages
{
    public class BasketModel : PageModel
    {

        private List<Product> BasketItems { get; set; }
        
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

        public void OnGet()
        {
            if (HttpContext.Session.GetString("itemforbasket") != null)
            {
                //this is to extract the added items that are passed from the product page
                BasketItems = JsonConvert.DeserializeObject<Product>(HttpContext.Session.GetString("itemforbasket"));
            }
        }

        

        public void AddItem(Product ProductId)
        {
            Product newItem = ProductId;

            if (BasketItems.Contains(newItem))
            {
                foreach (var item in BasketItems)
                {
                    if (item == newItem)
                    {
                        item.Quantity++;
                        return;
                    }
                    else
                    {
                        newItem.Quantity = 1;
                        BasketItems.Add(newItem);

                    }

                }

            }

        }


        public void SetItemQuantity(Product ProductId, int Quantity)
        {
            Product updatedItem = ProductId;
            if (Quantity == 0)
            {
                BasketItems.Remove(ProductId);
                return;
            }
            else
            {
                foreach (var item in BasketItems)
                {
                    if (item == updatedItem)
                    {
                        item.Quantity = Quantity;
                        return;

                    }
                }
            }
        }

        public void RemoveItem(Product ProductId)
        {
            Product itemsToRemove = ProductId;
            BasketItems.Remove(itemsToRemove);
        }

        public double CalculateItemsTotalPrice()
        {
            double subtotal = 0;
            foreach (var item in BasketItems)
            {
                _ = subtotal + item.ProductPrice;
            }
            return subtotal;
        }



    }
}
