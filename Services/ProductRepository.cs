using CS10_Project_Fisketorvet_V1.Helpers;
using CS10_Project_Fisketorvet_V1.Interfaces;
using CS10_Project_Fisketorvet_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CS10_Project_Fisketorvet_V1.Services
{
    public class ProductRepository : IProductRepository
    {
        public string jsonFilePath = @".\Data\Products.json";

        public Dictionary<int, List<Product>> ProductCatalog { get; set; }

        
        ///<summary> 
        ///Returns all products from the store with the passed store id.
        ///</summary>
        public List<Product> GetStoreProducts(int storeId)
        {
            ProductCatalog = JsonFileHelper<Dictionary<int, List<Product>>>.ReadJsonSingle(jsonFilePath);
            if (ProductCatalog.ContainsKey(storeId))
            {
                return ProductCatalog[storeId];
            }
            return new List<Product>();
        }

        ///<summary> 
        ///Returns all products from all stores.
        ///</summary>
        public List<Product> GetAllProducts()
        {
            ProductCatalog = JsonFileHelper<Dictionary<int, List<Product>>>.ReadJsonSingle(jsonFilePath);
            List<Product> productList = new List<Product>(); 
            foreach (var store in ProductCatalog.Values)
            {
                foreach (var p in store)
                {
                    productList.Add(p);
                }
            }
            return productList;
        }

        ///<summary> 
        ///Returns one specific product with the provided product id.
        ///</summary>
        public Product GetProduct(int id)
        {
            foreach (var p in GetAllProducts())
            {
                if (p.ProductId == id)
                {
                    return p;
                }
            }

            return new Product();
        }

        ///<summary> 
        ///Adds a new product to the store with the provided store id.
        ///If no such store id exists, a new one will be created.
        ///</summary>
        public void AddNewProduct(Product newProduct)
        {
            ProductCatalog = JsonFileHelper<Dictionary<int, List<Product>>>.ReadJsonSingle(jsonFilePath);
            List<int> allIds = new List<int>();
            int newId = 0;

            if (string.IsNullOrEmpty(newProduct.ImagePath))
            {
                newProduct.ImagePath = "NoPicAvailable.png";
            }

            foreach (var store in ProductCatalog)
            {
                foreach (var p in store.Value)
                {
                    allIds.Add(p.ProductId);
                }
            }

            if (allIds.Count != 0)
            {
                newId = allIds.Max() + 1;
            }
            else
            {
                newId = 1;
            }

            newProduct.ProductId = newId;

            if (!ProductCatalog.ContainsKey(newProduct.StoreID))
            {

                ProductCatalog.Add(newProduct.StoreID, new List<Product>() { newProduct });
            }
            else
            {
                ProductCatalog[newProduct.StoreID].Add(newProduct);
            }

            JsonFileHelper<Dictionary<int, List<Product>>>.WriteToJsonSingle(ProductCatalog ,jsonFilePath);

        }

        ///<summary> 
        ///Deletes the product with the given product id from the stores.
        ///</summary>
        public void DeleteProduct(int id)
        {
            ProductCatalog = JsonFileHelper<Dictionary<int, List<Product>>>.ReadJsonSingle(jsonFilePath);
            foreach (var list in ProductCatalog.Values)
            {
                foreach (var i in list)
                {
                    if(i.ProductId == id)
                    {
                        list.Remove(i);
                        break;
                    }
                }
            }
            JsonFileHelper<Dictionary<int, List<Product>>>.WriteToJsonSingle(ProductCatalog, jsonFilePath);
        }

        /// <summary>
        /// Updates a product with new data from form.
        /// </summary>
        public void UpdateProduct(Product product)
        {
            foreach (var p in GetAllProducts())
            {
                if (p.ProductId == product.ProductId)
                {
                    product = p;
                }
            }
            //not done yet
        }

        
    }
}
