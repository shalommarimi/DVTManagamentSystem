using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using DVTManagementSystem.Models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using WebMatrix.WebData;

namespace DVTManagementSystem.Models.AccountModel
{
    public class LostPasswordModel
    {
        
        [Required(ErrorMessage ="Please enter your email address to receive the reset password link")]
        [Display(Name ="Your email address")]
        [EmailAddress(ErrorMessage ="Not a valid email address")]
        public string email { get; set; }

    }
}
