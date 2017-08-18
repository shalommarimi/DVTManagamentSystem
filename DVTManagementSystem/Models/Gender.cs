using DVTManagementSystem.Models.ModelValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVTManagementSystem.Models
{
    [MetadataType(typeof(GenderMetadata))]
    public class Gender
    {
        public int GenderId { get; set; }
        public string GenderType { get; set; }

        public virtual  ICollection<UserProfile> UserProfile { get; set; }
    }
}