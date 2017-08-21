using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DVTManagementSystem.Models;
using DVTManagementSystem.Migrations;
using DVTManagementSystem.Models.Context;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DVTManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        DVTManagementSystemContext DVTcontext = new DVTManagementSystemContext();
        // GET: Admin
        public ActionResult UserList()
        {
            var users = DVTcontext.UserProfiles.ToList();
            return View(users);
        }
        // GET: Users/Approved 
        public ActionResult ApprovedUser(int id)
        {
            var UserUpdate = DVTcontext.UserProfiles.Where(u => u.UserProfileId == id).FirstOrDefault();
            return View(UserUpdate);
        }

        // POST: Approving users / editing user status 
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApprovedUser([Bind(Include = "UserId,FirstName,LastName,Status")] UserProfile user)
        {
            if (ModelState.IsValid)
            {

                //update feilds 
                user.FirstName = user.FirstName;
                user.LastName = user.LastName;


                DVTcontext.Entry(user).State = EntityState.Modified;

                DVTcontext.SaveChanges();

                return RedirectToAction("UserList");
            }
            return View(user);
        }

    }

}


