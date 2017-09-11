using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DVTManagementSystem.Models;
using DVTManagementSystem.Models.Context;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Net;


namespace DVTManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        DVTManagementSystemContext DVTcontext = new DVTManagementSystemContext();

        // GET: Admin
        public ActionResult UserList()
        {
            var users = DVTcontext.UserProfiles.Where(d => d.IsDeleted == false).ToList();
            return View(users);
        }
        // GET: Users/Approved 
        public ActionResult ApprovedUser(int id)
        {
           
            var User = DVTcontext.UserProfiles.Where(u => u.UserProfileId == id).FirstOrDefault();
            ViewBag.DepartmentId = new SelectList(DVTcontext.Departments, "DepartmentId", "DepartmentName", User.DepartmentId);
            ViewBag.GenderTypeId = new SelectList(DVTcontext.Genders, "GenderId", "GenderType", User.GenderTypeId);
            ViewBag.UserTypeId = new SelectList(DVTcontext.UserTypes, "UserTypeId", "UserRole",User.UserTypeId);
            return View(User);
        }

        // POST: Approving users / editing user status 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApprovedUser(UserProfile user)
        {
            if (ModelState.IsValid)
            {
                //update fields 
   
                DVTcontext.Entry(user).State = EntityState.Modified;
                DVTcontext.SaveChanges();
                

                return RedirectToAction("UserList");
            }
            return View(user);
        }
        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var us = DVTcontext.UserProfiles.Where(u => u.UserProfileId == id).FirstOrDefault();
            if (us == null)
            {
                return HttpNotFound();
            }
            return View(us);
        }

        // GET: Users/Delete/5
        public ActionResult Delete()
        {
          
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult DeleteUser(int id)
        {
            var us = DVTcontext.UserProfiles.Where(u => u.UserProfileId == id).FirstOrDefault();

            us.IsDeleted = true;
            DVTcontext.Entry(us).State = EntityState.Modified;
            DVTcontext.SaveChanges();

            return RedirectToAction("UserList");
        }

    }
}


