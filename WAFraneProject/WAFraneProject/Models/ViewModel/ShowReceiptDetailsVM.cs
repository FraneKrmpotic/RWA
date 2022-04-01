using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAFraneProject.Models.ViewModel
{
    public class ShowReceiptDetailsVM
    {
        public IEnumerable<ItemDetails> ItemDetails { get; set; }
        public CreditCard CreditCard { get; set; }
        public Commercialist Commercialist { get; set; }
    }
}