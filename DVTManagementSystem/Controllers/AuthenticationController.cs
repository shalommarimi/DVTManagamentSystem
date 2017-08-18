﻿using DVTManagementSystem.Models;
using DVTManagementSystem.Models.Context;
using DVTManagementSystem.Services;
using System.Linq;
using System.Web.Mvc;

namespace DVTManagementSystem.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(UserProfile profile)
        {
            using (var context = new DVTManagementSystemContext())
            {

                try
                {
                    var PasswordHashingmMethod = new PasswordHashing();
                    string HashedPassword = PasswordHashingmMethod.HashInput(profile.PasswordHash);




                    if (ModelState.IsValid == true)
                    {
                        var user = context.UserProfiles.Single(u => u.EmailAddress == profile.EmailAddress && u.PasswordHash == profile.PasswordHash);
                        if (user != null)
                        {
                            //Session["UserId"] = user.PkLoginId.ToString();
                            //Session["Username"] = user.Username.ToString();
                            return RedirectToAction("Dashboard", "Applicant");

                        }
                        else
                        {
                            ModelState.AddModelError("", "Username or Password is incorrect");

                        }
                    }
                }
                catch (System.Exception)
                {
                    ModelState.AddModelError("", "Database Access Error");
                    //  throw;
                }
            }


            return View();
        }
    }
}