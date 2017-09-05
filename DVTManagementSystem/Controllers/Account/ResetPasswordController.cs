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
using DVTManagementSystem.Models.Context;

namespace DVTManagementSystem.Controllers.Account
{
    public class ResetPasswordController : Controller
    {

        //[Route("ResetPassword/ResetPassword/id/resettoken")]
        DVTManagementSystemContext db = new DVTManagementSystemContext();
        // GET: ResetPassword
        [HttpGet]
        public ActionResult ResetPassword( string resettoken, int id)
        {
            ResetPasswordModel _resetPasswordmodel = new ResetPasswordModel();
            _resetPasswordmodel.ReturnToken = resettoken;
            _resetPasswordmodel.userId = id;
            return View(_resetPasswordmodel);
        }


        [HttpPost]
        [AllowAnonymous]
       // [ValidateAntiForgeryToken]
        public ActionResult ResetPassword ( ResetPasswordModel _resetPasswordmodel)
        {
            if (ModelState.IsValid)
            {
                
                bool response = WebSecurity.ResetPassword(_resetPasswordmodel.ReturnToken, _resetPasswordmodel.Password);
                if (response)
                {
                    var user = db.UserProfiles.Find(_resetPasswordmodel.userId);
                    user.ConfirmPasswordHash = _resetPasswordmodel.Password;

                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
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