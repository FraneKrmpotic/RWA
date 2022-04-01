using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WAFraneProject.Models
{
    public class City
    {
        public int IDCity { get; set; }
        public string Name { get; set; }
        public int CountryID { get; set; }
        public override string ToString()
        => $"{Name}";
    }
}