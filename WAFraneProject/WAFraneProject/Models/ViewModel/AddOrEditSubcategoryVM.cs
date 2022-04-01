using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAFraneProject.Models.ViewModel
{
    public class AddOrEditSubcategoryVM
    {
        public IEnumerable<Category> Categories { get; set; }
        public Subcategory Subcategory { get; set; }
    }
}