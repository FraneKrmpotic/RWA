using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WAFraneProject.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "This field can't be empty!")] // Postaviti gdje imamo neki unos ili tako nesto
        public string Title { get; set; }
    }
}