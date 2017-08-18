using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DVTManagementSystem.Models.ModelValidation
{
    public class AddressMetadata
    {

        [Required]
        public int AddressTypeId { get; set; }

        [Required ]
        public string HouseNumber { get; set; }

        [Required ]
        public int SuburbId { get; set; }
        
        [ForeignKey("AddressTypeId")]
        public virtual AddressType AddressType { get; set; }

        [ForeignKey("SuburbId")]
        public virtual Suburb Suburb { get; set; }
    }
}