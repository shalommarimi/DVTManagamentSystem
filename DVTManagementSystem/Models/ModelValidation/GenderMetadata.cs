using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVTManagementSystem.Models.ModelValidation
{
    public class GenderMetadata
    {
        [Required ]
        [StringLength(7)]
        public string GenderType { get; set; }
    }
}