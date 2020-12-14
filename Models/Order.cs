using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS10_Project_Fisketorvet_V1.Models
{
    public class Order
    {
        public const string JsonOrders = @"Data/Orders.json";
        public static Dictionary<int, Order> Catalog = Helpers.JsonFileHelper<Order>.ReadJson(JsonOrders);

        public int ID
        {
            get;set;
        }
        [Required(ErrorMessage = "The Zip code is required")]
        [Range(1000, 9999)]
        public int ZIP
        {
            get;set;
        }
        [Required(ErrorMessage = "The street is required")]
        [MaxLength(50)]
        public string Street
        {
            get;set;
        }
        [Required(ErrorMessage = "The street number is required")]
        public string StreetNR
        {
            get;set;
        }
        public List<int[]> Items
        {
            get;set;
        }
        public int OwnerID
        {
            get;set;
        }
        public DateTime Date
        {
            get;set;
        }
        public double Price
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
                    order.Date = DateTime.Now;
                    Catalog.Add(i, order);
                    Helpers.JsonFileHelper<Order>.WriteToJson(Catalog, JsonOrders);
                    break;
                }
            }
        }
        public static void Update(Order order)
        {
            foreach (Order c in Catalog.Values)
            {
                if (c.ID == order.ID)
                {
                    c.ZIP = order.ZIP;
                    c.Street = order.Street;
                    c.StreetNR = order.StreetNR;
                    Helpers.JsonFileHelper<Order>.WriteToJson(Catalog, JsonOrders);
                    break;
                }
            }
        }
        public static void Delete(int id)
        {
            Catalog.Remove(id);
            Helpers.JsonFileHelper<Order>.WriteToJson(Catalog, JsonOrders);
        }
    }
}
