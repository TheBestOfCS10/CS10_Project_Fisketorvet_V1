using CS10_Project_Fisketorvet_V1.Interfaces;
using CS10_Project_Fisketorvet_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS10_Project_Fisketorvet_V1.Pages.Stores
{
    public class StoresCatalog : IStores
    {
        private Dictionary<int, Store> stores { get; set; }
        public StoresCatalog()
        {
            stores = new Dictionary<int, Store>();
            stores.Add(1, new Store() { Id = 1, Name = "Lidl", Description = "Lidl is one of Europe's leading supermarket chains. The principle at Lidl is to make it as easy for the customer as possible. At Lidl at Fisketorvet it is offered groceries of the best quality to the best price. Welcome in Lidl at Fisketorvet.",ImageName= "Lidl.png" });
            stores.Add(2, new Store() { Id = 2, Name = "Jysk", Description = "In JYSK’s city store at Fisketorvet, customers will find a handpicked selection of JYSK’s assortment within home accessories with a focus on design and quality at fair prices. The city store welcomes customers inside a Scandinavian universe, where they can find inspiration for interior decorating and experience new home trends.JYSK’s competent employees are always at hand and ready to help with guidance and advice. Apart from the products on display, customers in the city store also have access to JYSK’s complete assortment via the chain’s webshop. Welcome in JYSK’s city store at Fisketorvet.", ImageName = "JYSK.jpg" });

        }
        public Dictionary<int , Store> AllStores()
        {
            return stores;
        }
        public Dictionary<int, Store> FilterStores(string criteria)
        {
            Dictionary<int, Store> empty = new Dictionary<int, Store>();
            if (criteria !=null)
            {
                foreach (var item in stores.Values)
                {
                    if (item.Name.StartsWith(criteria))
                    {
                        empty.Add(item.Id, item);
                    }
                }
            }
            return empty;
        }
    }
}
