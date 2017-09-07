using DVTManagementSystem.Models.ModelValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVTManagementSystem.Models
{
    [MetadataType(typeof(CityMetadata))]
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int ProvinceId { get; set; }
        public virtual Province  Province { get; set; }
        public virtual ICollection<Suburb> Suburb { get; set; }
    }
}