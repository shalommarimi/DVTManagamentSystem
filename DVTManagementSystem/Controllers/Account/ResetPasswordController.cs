using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using DVTManagementSystem.Models.AccountModel;


namespace DVTManagementSystem.Controllers.Account
{
    public class ResetPasswordController : Controller
    {
        // GET: ResetPassword
        public ActionResult ResetPassword( string resettoken)
        {
            ResetPasswordModel _resetPasswordmodel = new ResetPasswordModel();
            _resetPasswordmodel.ReturnToken = resettoken;

            return View(_resetPasswordmodel);
        }
    }
}