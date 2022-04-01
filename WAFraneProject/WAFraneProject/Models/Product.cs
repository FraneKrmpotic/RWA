using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAFraneProject.Models
{
    public class Product
    {
        public int IDProduct { get; set; }
        public string Title { get; set; }
        public string NumberOfProducts { get; set; }
        public string Color { get; set; }
        public int MinimalAmountInStock { get; set; }
        public int PriceWithoutPDV { get; set; }
        public string Subcategory { get; set; }
        public int SubcategoryID { get; set; } 
    }
}