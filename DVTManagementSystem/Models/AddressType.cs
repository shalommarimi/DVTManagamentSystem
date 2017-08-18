using DVTManagementSystem.Models.ModelValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVTManagementSystem.Models
{
    [MetadataType(typeof(AddressTypeMetadata))]
    public class AddressType
    {

        public int AddressTypeId { get; set; }

        public string TypeOfAddress { get; set;}

        public virtual ICollection<Address> Address { get; set; }
    }
}