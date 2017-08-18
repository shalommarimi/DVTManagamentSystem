using DVTManagementSystem.Models.ModelValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVTManagementSystem.Models
{
    [MetadataType(typeof(PostalCodeMetadata))]
    public class PostalCode
    {
        public int PostalCodeId { get; set; }

        public string PostalCodeNumber { get; set; }

        public virtual ICollection <Suburb> Suburb { get; set; }

    }
}