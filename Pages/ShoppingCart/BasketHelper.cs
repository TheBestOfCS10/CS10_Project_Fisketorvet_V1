using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS10_Project_Fisketorvet_V1.Pages.LoggedInUser;

namespace CS10_Project_Fisketorvet_V1.Pages.ShoppingCart
{
    public class BasketHelper
    {
        static Models.Basket basket = new Models.Basket();
        public static void AddToBasket(int id, int quantity)
        {
            CheckForBasket();
            basket.Add(id, quantity);
        }
        public static void ChangeQuantity(int id, int quantity)
        {
            CheckForBasket();
            basket.ChangeQuantity(id, quantity);
        }
        public static void RemoveFromBasket(int id)
        {
            CheckForBasket();
            basket.Remove(id);
        }
        public static void CheckForBasket()
        {
            try
            {
                if (Models.Customer.Catalog[CurrentUser.User[0]].BasketID != 0)
                {
                    if (Models.Basket.Catalog[Models.Customer.Catalog[CurrentUser.User[0]].BasketID] != null)
                    {
                        basket = Models.Basket.Catalog[Models.Customer.Catalog[CurrentUser.User[0]].BasketID];
                    }
                    else throw new ArgumentException();
                }
                else throw new ArgumentException();
            }
            catch (ArgumentException)
            {
                Models.Basket.Create(basket);
                Models.Customer.Catalog[CurrentUser.User[0]].BasketID = basket.ID;
                Helpers.JsonFileHelper<Models.Customer>.WriteToJson(Models.Customer.Catalog, Models.Customer.JsonCustomers);
            }
        }
    }
}
