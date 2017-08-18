using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVTManagementSystem.Models
{
    public class Suburb
    {
        public int SuburbId  { get; set; }

        public string SuburbName { get; set; }

        public string StreetName { get; set; }

        public int PostalCodeId { get; set; }

        public int CityId { get; set; }


        public virtual PostalCode PostalCode{ get; set; }

        public virtual City  City { get; set; }

        public virtual ICollection <Address> Address { get; set; }


    }
}