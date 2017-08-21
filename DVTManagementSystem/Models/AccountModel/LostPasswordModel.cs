using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using DVTManagementSystem.Models;
using System.Data.Entity;
using WebMatrix.WebData;

namespace DVTManagementSystem.Models.AccountModel
{
    public class LostPasswordModel
    {
        //waiting for the login model sothat i can envoke the model state
        public string email { get; set; }
    }
}
