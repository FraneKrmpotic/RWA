using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAFraneProject.Models
{
    public class CreditCard
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
    }
}