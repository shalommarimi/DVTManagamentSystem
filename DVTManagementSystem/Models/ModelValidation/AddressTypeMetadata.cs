using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVTManagementSystem.Models.ModelValidation
{
    public class AddressTypeMetadata
    {
        [Required]
       [StringLength (20)]
        public string TypeOfAddress { get; set; }
    }
}