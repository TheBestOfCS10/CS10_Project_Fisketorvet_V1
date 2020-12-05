using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Threading.Tasks;

namespace CS10_Project_Fisketorvet_V1.Models
{
    public class Product
    {
        const string JsonProducts = @"Data/Products.json";
        public static Dictionary<int, List<Product>> ProductCatalog = Helpers.JsonFileHelper<List<Product>>.ReadJson(JsonProducts);

        public int ProductId { get; set; }
        public int StoreID { get; set; }

        [Required(ErrorMessage = "A product name is required.")]
        [StringLength(32, ErrorMessage = "The product name must not be longer than 32 characters.")]
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "The product price is required.")]
        [Range(0.1, 500000.0, ErrorMessage = "The price must be at least 0.1 kr.")]
        public double ProductPrice { get; set; }

        public string ImagePath { get; set; }
        
        public static Product GetProduct(int id, Dictionary<int, List<Product>> catalog)
        {
            for (int i = 1; i <= catalog.Count; i++)
            {
                List<Product> list = catalog[i];
                foreach (Product p in list)
                {
                    if (p.ProductId == id) return p;
                }
            }
            return null;
        }
    }
}
