using System;
using System.Collections.Generic;
using CS10_Project_Fisketorvet_V1.Interfaces;
using CS10_Project_Fisketorvet_V1.Models;

namespace CS10_Project_Fisketorvet_V1.Catalogs
{
    public class ProductCatalog 
    {
        private List<Product> ListofProducts { get; set; }

        public ProductCatalog()
        {
            //ListofProducts = new List<Product>();
            //ListofProducts.Add(new Product() { Id = "p01", Name = "The Elle Dress", Brand = "Zara", Description = "A white flowy dress", Price = 200.00 });
            //ListofProducts.Add(new Product() { Id = "p02", Name = "The Radu Coat", Brand = "SuperDry", Description = "Camel knee-length wool coat", Price = 500.00 });
            //ListofProducts.Add(new Product() { Id = "p03", Name = "Niko's Knit Sweater", Brand = "H&M", Description = "Navy blue thick knitted sweater", Price = 250.00 });
            //ListofProducts.Add(new Product() { Id = "p04", Name = "50s High Waist", Brand = "Vero Moda", Description = "Black high-waisted men's jeans", Price = 400.00 });
            //ListofProducts.Add(new Product() { Id = "p05", Name = "Gabor's Hoodie", Brand = "NA-KD", Description = "Brown hoodie with designs", Price = 150.00 });
        }
    }
}
