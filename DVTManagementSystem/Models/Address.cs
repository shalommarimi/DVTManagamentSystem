using DVTManagementSystem.Models.ModelValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVTManagementSystem.Models
{
    [MetadataType(typeof(AddressMetadata))]
    public class Address
    {

        public int AddressId { get; set; }
        public string  HouseNumber { get; set; }
        public int AddressTypeId { get; set; }

        public int SuburbId { get; set; }

        public virtual AddressType  AddressType { get; set; }

        public virtual Suburb  Suburb { get; set; }

        public virtual ICollection<UserProfile>  UserProfile { get; set; }
    }
}