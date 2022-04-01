using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAFraneProject.Models.ViewModel
{
    public class AddOrEditProductVM
    {
        public IEnumerable<Subcategory> Subcategories { get; set; }
        public Product Product { get; set; }
    }
}