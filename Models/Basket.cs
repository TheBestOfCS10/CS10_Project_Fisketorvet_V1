using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS10_Project_Fisketorvet_V1.Models
{
    public class Basket
    {
        //List of an array, each array holds the product and its quantity like this array[0] = productid, array[1]= quantity
        //To add/remove items use a method
        const string JsonBaskets = @"Data\Baskets.json";
        public static Dictionary<int, Basket> Catalog = Helpers.JsonFileHelper<Basket>.ReadJson(JsonBaskets);
        List<int[]> _items { get; }
        int _id;

        public List<int[]> Items
        {
            get; set;
        }
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public static void Create(Basket basket)
        {
            for(int i=1; i<=Catalog.Count+1; i++)
            {
                if (!Catalog.ContainsKey(i))
                {
                    basket.ID = i;
                    basket.Items = new List<int[]>();
                    Catalog.Add(i, basket);
                    break;
                }
            }
            UpdateCatalog();
        }
        public void Add(int id, int quantity)
        {
            if (quantity > 0)
            {
                int[] newarray = new int[2] { id, quantity };
                if (Items.Count == 0)
                {
                    Items.Add(newarray);
                    UpdateCatalog();
                    return;
                }
                foreach (int[] i in Items)
                {
                    if (i[0] == id)
                    {
                        i[1] += quantity;
                        UpdateCatalog();
                        return;
                    }
                }
                Items.Add(newarray);
                UpdateCatalog();
                return;
            }
            else if(quantity<0)
            {
                if (Items.Count == 0) return;
                foreach (int[] i in Items)
                {
                    if (i[0] == id)
                    {
                        i[1] += quantity;
                        if (i[1] <= 0) Remove(id);
                        UpdateCatalog();
                        return;
                    }
                }
            }
        }
        public void ChangeQuantity(int id, int quantity)
        {
            int[] newarray = new int[2] { id, quantity };
            foreach (int[] i in Items)
            {
                if(i[0] == newarray[0])
                {
                    i[1] = newarray[1];
                    break;
                }
            }
            UpdateCatalog();
        }
        public void Remove(int id)
        {
            foreach(int[] i in Items)
            {
                if(i[0] == id)
                {
                    i[1] = 0;
                    Items.Remove(i);
                    break;
                }
            }
            UpdateCatalog();
        }
        public static Basket GetBasket(int id)
        {
            return Catalog[id];
        }
        public void ClearBasket()
        {
            Items.Clear();
            Helpers.JsonFileHelper<Basket>.WriteToJson(Catalog, JsonBaskets);
        }
        public static void UpdateCatalog()
        {
            Helpers.JsonFileHelper<Basket>.WriteToJson(Catalog, JsonBaskets);
        }
    }
}
