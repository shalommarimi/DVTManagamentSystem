using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVTManagementSystem.Models.ModelValidation
{
    public class UserTypeMetadata
    {
        [Required ]
        [StringLength (100)]
        public string UserRole { get; set; }
    }
}