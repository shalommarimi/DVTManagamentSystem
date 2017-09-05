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
using System.Text;

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
            
            //Checking if the userEmail exist
            using (var _userProfileDBContext = new DVTManagementSystemContext())
            {
                //var _ExistUser = (from x in _userProfileDBContext.UserProfiles
                //                where x.EmailAddress == _LostPasswordmodel.EmailAddress
                //                 select x).FirstOrDefault();

                

                if (!WebSecurity.UserExists(_LostPasswordmodel.EmailAddress))
                {
                    WebSecurity.CreateUserAndAccount(_LostPasswordmodel.EmailAddress, "12345");
                }
                //Generating the password token for User

                _LostPasswordmodel.UserId = _userProfileDBContext.UserProfiles.Where(y => y.EmailAddress == _LostPasswordmodel.EmailAddress)
                                                                              .Select(x => x.UserProfileId)
                                                                              .FirstOrDefault();

                if (WebSecurity.UserExists(_LostPasswordmodel.EmailAddress))
                {
                    var token = WebSecurity.GeneratePasswordResetToken(_LostPasswordmodel.EmailAddress);

                    try
                    {
                        string resetPasswordLink = "<a href='" + Url.Action("ResetPassword", "ResetPassword", new { reset = token,id =_LostPasswordmodel.UserId}, "http:/localhost:51927") + "'>Reset Password Link <a/>";

                        StringBuilder stringbuilder = new StringBuilder();
                        string subject = "Reset your password DVT management system";
                        string from = "dvtdonotreply@gmail.com";

                        MailMessage _messages = new MailMessage(from, _LostPasswordmodel.EmailAddress);
                        _messages.Subject = subject;
                        stringbuilder.Append("Hi " + "<br></br>");
                        stringbuilder.Append("<br></br>" + "Click the link to reset the password" + " " + resetPasswordLink + "");
                        _messages.Body = stringbuilder.ToString();

                        _messages.IsBodyHtml = true;

                        SmtpClient _client = new SmtpClient();
                        _client.Host = "smtp.gmail.com";
                        _client.Port = 587;

                        _client.UseDefaultCredentials = false;
                        _client.Credentials = new System.Net.NetworkCredential
                        ("dvtdonotreply@gmail.com", "March2017!@#");
                        _client.EnableSsl = true;

                        _client.Send(_messages);

                        ViewBag.Message = "email has been sent";
                    }
                    catch (Exception)
                    {

                        ViewBag.Message = "Problem occured while email was trying to be sent";
                    }
                    //generating the link for reset password
                }

            }
            return View();
        }

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

            public string PasswordHash { get; set; }

            public int DepartmentId { get; set; }

            public bool IsApproved { get; set; }

            public static string PasswordHashing { get; internal set; }
        }
    }
}