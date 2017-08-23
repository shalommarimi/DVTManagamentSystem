using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DVTManagementSystem;
using DVTManagementSystem.Models;
using DVTManagementSystem.Models.Context;

namespace DVTManagementSystem.Controllers
{
    public class RegistrationController : Controller
    {
        public ActionResult Register(UserProfile register)
        {
            if (ModelState.IsValid)
            {
                using (DVTManagementSystemContext db = new DVTManagementSystemContext())
                {
                    db.UserProfiles.Add(register);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = register.FirstName + " " + register.LastName + " " + register.IdentityNumber + " " +
                    register.DateOfBirth + " " + register.Gender + " " + register.PhoneNumber + "  " +
                    register.PhoneNumber + " " + register.Department + " " + register.EmailAddress + " " +
                    register.ConfirmEmailAddress + " " + register.PasswordHash + " " + register.ConfirmPasswordHash + " " + "Sucessfully registered";

            }
            return View();
        }

    }
}
    