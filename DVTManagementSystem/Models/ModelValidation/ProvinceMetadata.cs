using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVTManagementSystem.Models.ModelValidation
{
    public class ProvinceMetadata
    {
        [Required]
        public string ProvinceName { get; set; }
    }
}