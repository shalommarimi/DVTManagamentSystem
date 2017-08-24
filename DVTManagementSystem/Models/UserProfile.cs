using DVTManagementSystem.Models.ModelValidation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DVTManagementSystem.Models
{
    [MetadataType(typeof(UserProfileMetadata))]
    public class UserProfile
    {

        public int UserProfileId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IdentityNumber { get; set; }

        public string DateOfBirth { get; set; }

        public int GenderTypeId { get; set; }

        public int UserTypeId { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string ConfirmEmailAddress { get; set; }

        public string PasswordHash { get; set; }

        public string ConfirmPasswordHash { get; set; }

        public int DepartmentId { get; set; }

        public bool IsApproved { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual UserType UserType { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public static string PasswordHashing { get; internal set; }
    }
}