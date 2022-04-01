using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAFraneProject.Models
{
    public class Client
    {
        public int IDClient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CityID { get; set; }
        public string City { get; set; } // zbog broj procedura i jednostavnosti
        public string Country { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}