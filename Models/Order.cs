using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS10_Project_Fisketorvet_V1.Models
{
    public class Order
    {
        const string JsonOrders = @"Data/Orders.json";
        public static Dictionary<int, Order> Catalog = Helpers.JsonFileHelper<Order>.ReadJson(JsonOrders);

        public int ID
        {
            get;set;
        }
        public int ZIP
        {
            get;set;
        }
        public string Street
        {
            get;set;
        }
        public string StreetNR
        {
            get;set;
        }
        public List<int[]> Items
        {
            get;set;
        }

        public static void Create(Order order)
        {
            for (int i = 1; i <= Catalog.Count + 1; i++)
            {
                if (!Catalog.ContainsKey(i))
                {
                    order.ID = i;
                    Catalog.Add(i, order);
                    Helpers.JsonFileHelper<Order>.WriteToJson(Catalog, JsonOrders);
                    break;
                }
            }
        }
    }
}
