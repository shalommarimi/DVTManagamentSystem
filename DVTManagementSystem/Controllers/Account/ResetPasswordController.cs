using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using DVTManagementSystem.Models.AccountModel;
using System.Net.Security;
using System.Web.Mail;
using WebMatrix.WebData;

namespace DVTManagementSystem.Controllers.Account
{
    public class ResetPasswordController : Controller
    {
        // GET: ResetPassword
        [HttpGet]
        public ActionResult ResetPassword( string resettoken)
        {
            ResetPasswordModel _resetPasswordmodel = new ResetPasswordModel();
            _resetPasswordmodel.ReturnToken = resettoken;

            return View(_resetPasswordmodel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword ( ResetPasswordModel _resetPasswordmodel)
        {
            if (ModelState.IsValid)
            {
                
                bool response = WebSecurity.ResetPassword(_resetPasswordmodel.ReturnToken, _resetPasswordmodel.Password);
                if (response)
                {
                    ViewBag.Message = "Succesfully changed the password";
                }
                else
                {
                    ViewBag.Message = "Password change was unsuccesful";
                }
            }
            return View(_resetPasswordmodel);
        }


    }
}