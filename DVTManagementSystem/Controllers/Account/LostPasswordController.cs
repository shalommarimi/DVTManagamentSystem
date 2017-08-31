using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DVTManagementSystem.Models;
using System.Data.SqlClient;
using System.Data.Entity;
using DVTManagementSystem.Models.AccountModel;
using DVTManagementSystem.Models.Context;
using System.Web.Security;
using System.Net.Mail;
using WebMatrix.WebData;


namespace DVTManagementSystem.Controllers.Account
{
    public class LostPasswordController : Controller
    {
        // GET: LostPassword
        [HttpGet]
        [AllowAnonymous]
        public ActionResult LostPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
       /// [ValidateAntiForgeryToken]
        public ActionResult LostPassword(LostPasswordModel _LostPasswordmodel)
        {

            if (ModelState.IsValid)
            {
                MembershipUser user;
                //Checking if the userEmail exist
                using (var _userProfileDBContext = new DVTManagementSystemContext())
                {
                    var _ExistUser = (from x in _userProfileDBContext.UserProfiles
                                      where x.EmailAddress == _LostPasswordmodel.EmailAddress
                                      select x.FirstName).FirstOrDefault();
                    if (_ExistUser != null)
                    {

                        user = Membership.GetUser(_ExistUser.ToString());
                    }
                    else
                    {
                        user = null;
                    }
                    //Generating the password token for User
                    if (user != null)
                    {
                        
                        var token=WebSecurity.GeneratePasswordResetToken(user.UserName);


                        //generating the link for reset password
                        string resetPasswordLink = "<a href='" + Url.Action("ResetPassword", "Account", new { reset = token }, "https") + "'>Reset Password Link <a/>";

                        string subject = "Reset your password DVT management system";
                        string body = "Click the link to reset the password";
                        string from = "dvtdonotreply@gmail.com";

                        MailMessage _messages = new MailMessage(from, _LostPasswordmodel.EmailAddress);
                        _messages.Subject = subject;
                        _messages.Body = body;
                        _messages.IsBodyHtml = true;
                        SmtpClient _client = new SmtpClient();
                        try
                        {
                            _client.Send(_messages);
                        }
                        catch (Exception ex)
                        {

                            ModelState.AddModelError("", "Have issues sending email:" + ex.Message);
                        }
                    }

                    else
                    {
                        ModelState.AddModelError("", "No user found by that email:");
                    }

                }

            }
            return View(_LostPasswordmodel);
        }
    }
}