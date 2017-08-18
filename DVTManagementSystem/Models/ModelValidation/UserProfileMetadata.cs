using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DVTManagementSystem.Models.ModelValidation
{
    public class UserProfileMetadata
    {
        [Required ]
        [StringLength(200)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(200)]
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string DateOfBirth { get; set; }

        [Required]
        public int GenderTypeId { get; set; }

        public int UserTypeId { get; set; }

        [Required ]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [Required ]
        [EmailAddress ]
        public string EmailAddress { get; set; }

        [NotMapped ]
        public string ConfirmEmailAddress { get; set; }

        [Required ]
        public string PasswordHash { get; set; }

        [NotMapped ]
        public string ConfirmPasswordHash { get; set; }

        public int DepartmentId { get; set; }

        public byte IsApproved { get; set; }


        [ForeignKey("GenderTypeId")]
        public virtual Gender Gender { get; set; }

        [ForeignKey("UserTypeId")]
        public virtual UserType UserType { get; set; }


        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}