using CS10_Project_Fisketorvet_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS10_Project_Fisketorvet_V1.Interfaces
{
    public interface IProductRepository
    {
        public List<Product> GetStoreProducts(int storeId);
        public void AddNewProduct(Product newProduct);
        public List<Product> GetAllProducts();
        public Product GetProduct(int id);
        public void DeleteProduct(int id);
        public void UpdateProduct(Product product);

    }
}
