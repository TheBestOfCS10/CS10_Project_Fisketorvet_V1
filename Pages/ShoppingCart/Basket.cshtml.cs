using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS10_Project_Fisketorvet_V1.Interfaces;
using CS10_Project_Fisketorvet_V1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS10_Project_Fisketorvet_V1.Pages
{
    public class BasketModel : PageModel
    {
        public List<Product> Product;
        private List<Product> BasketItems { get; set; }
        
        private static BasketModel _instance;

        public static BasketModel Instance
        {
            get
            {
                if ( _instance == null)
                {
                    _instance = new BasketModel();
                }
                return _instance;
            }
        }

        public void AddItem(Product Id)
        {
            Product newItem = Id;

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







        public void SetItemQuantity(Product Id, int quantity)
        {
            Product updatedItem = Id;
            if (quantity == 0)
            {
                BasketItems.Remove(Id);
                return;
            }
            else
            {
                foreach (var item in BasketItems)
                {
                    if (item == updatedItem)
                    {
                        item.Quantity = quantity;
                        return;

                    }
                }
            }
        }

        public void RemoveItem(Product Id)
        {
            Product itemsToRemove = Id;
            BasketItems.Remove(itemsToRemove);
        }

        public double CalculateItemsTotalPrice()
        {
            double subtotal = 0;
            foreach (var item in BasketItems)
            {
                _ = subtotal + item.Price;
            }
            return subtotal;
        }



    }
}
