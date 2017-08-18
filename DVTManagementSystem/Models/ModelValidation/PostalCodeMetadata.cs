using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVTManagementSystem.Models.ModelValidation
{
    public class PostalCodeMetadata
    {
        [Required]
    
        [MaxLength(4)]
        [MinLength(4)]
        public string PostalCodeNumber { get; set; }
    }
}