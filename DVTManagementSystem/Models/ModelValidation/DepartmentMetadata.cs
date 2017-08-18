using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVTManagementSystem.Models.ModelValidation
{
    public class DepartmentMetadata
    {
        [Required]
        [StringLength (20)]
        public string DepartmentName { get; set; }
        [Required ]
        public string DepartmentDescription { get; set; }
    }
}