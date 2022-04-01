    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAFraneProject.Models
{
    public class Receipt
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public string Number { get; set; }
        public string Date { get; set; }
        public string Comment { get; set; }
        public string Client { get; set; }
        public string CardNumber { get; set; }
        public string CommercialistName { get; set; }
        public string Price { get; set; }
        public string Product { get; set; }
        public string Subcategory { get; set; }
        public string Category { get; set; }


    }
}