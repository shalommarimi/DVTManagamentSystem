using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using DVTManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using WebMatrix.WebData;

namespace DVTManagementSystem.Models.AccountModel
{
    public class ResetPasswordModel
    {
        public int userId { get; set; }
        [Required]
         [Display(Name ="New Password")]
         [DataType(DataType.Password)]
         public string Password { get; set; }

        [Required]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)] 
        [Compare("Password", ErrorMessage ="Password does not match with the new Password")] 
         public string ConfirmPassword { get; set; }

        [Required]
        public string ReturnToken { get; set; }
    }
}