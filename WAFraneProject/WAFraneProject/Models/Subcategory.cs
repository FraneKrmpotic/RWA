using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WAFraneProject.Models
{
    public class Subcategory
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "This field can't be empty!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "This field can't be empty!")]
        public string Category { get; set; }
        public int CategoryID { get; set; }
    }
}