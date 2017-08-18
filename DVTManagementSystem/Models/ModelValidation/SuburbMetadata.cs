using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DVTManagementSystem.Models.ModelValidation
{
    public class SuburbMetadata
    {
        [Required]
        public string SuburbName { get; set; }

        [Required ]
        public string StreetName { get; set; }

        [Required ]
        public int PostalCodeId { get; set; }

        [Required ]
        public int CityId { get; set; }


        [ForeignKey("PostalCodeId")]
        public virtual PostalCode PostalCode { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }
    }
}