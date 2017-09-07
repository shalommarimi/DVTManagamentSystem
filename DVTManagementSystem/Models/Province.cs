using DVTManagementSystem.Models.ModelValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVTManagementSystem.Models
{
    [MetadataType(typeof(ProvinceMetadata))]
    public class Province
    {
        public int ProvinceId { get; set; }

        public string ProvinceName { get; set; }

        public virtual ICollection<City> City { get; set; }
    }
}