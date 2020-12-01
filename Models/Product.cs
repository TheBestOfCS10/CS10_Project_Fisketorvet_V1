using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS10_Project_Fisketorvet_V1.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int StoreID { get; set; }
        [Required(ErrorMessage = "A product name is required.")]
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }
        [Required(ErrorMessage = "The product price is required.")]
        [Range(0.1, 500000, ErrorMessage = "The price must be at least 0.1 kr.")]
        public double ProductPrice { get; set; }
        public string ImagePath { get; set; }
    }
}
