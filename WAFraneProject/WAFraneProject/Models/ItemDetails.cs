using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAFraneProject.Models
{
    public class ItemDetails
    {
        public int IDItem { get; set; }
        public int Amount { get; set; }
        public int PricePerPiece { get; set; }
        public int Dicount { get; set; }
        public int TotalPrice { get; set; }


        public string Product { get; set; }
        public string NumberOfProducts { get; set; }
        public string Color { get; set; }
        public int MinimalAmountInStock { get; set; }
        public int PriceWithoutPDV { get; set; }

        public string Subcategory { get; set; }
        public string Category { get; set; }
    }
}