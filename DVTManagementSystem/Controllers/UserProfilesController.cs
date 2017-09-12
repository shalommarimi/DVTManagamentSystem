using DVTManagementSystem.Models;
using DVTManagementSystem.Models.Context;
using DVTManagementSystem.Services;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
<<<<<<< HEAD
using DVTManagementSystem.Models;
using DVTManagementSystem.Models.Context;

=======
>>>>>>> d572de5d6a434cb7ee54c1292847c85ae375613b

namespace DVTManagementSystem.Controllers
{
    public class UserProfilesController : Controller
    {
        private DVTManagementSystemContext db = new DVTManagementSystemContext();

        // GET: UserProfiles
        public ActionResult Index()
        {
            var userProfiles = db.UserProfiles.Include(u => u.Department).Include(u => u.Gender).Include(u => u.UserType);
            return View(userProfiles.ToList());
        }

        // GET: UserProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile userProfile = db.UserProfiles.Find(id);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            return View(userProfile);
        }

        // GET: UserProfiles/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            ViewBag.GenderTypeId = new SelectList(db.Genders, "GenderId", "GenderType");
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "UserRole");
            return View();
        }

<<<<<<< HEAD
=======
        public ActionResult UserProfile()
        {
            return View();
        }


>>>>>>> d572de5d6a434cb7ee54c1292847c85ae375613b
        // POST: UserProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserProfileId,FirstName,LastName,IdentityNumber,DateOfBirth,GenderTypeId,UserTypeId,PhoneNumber,EmailAddress,PasswordHash,DepartmentId,IsApproved")] UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                db.UserProfiles.Add(userProfile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", userProfile.DepartmentId);
            ViewBag.GenderTypeId = new SelectList(db.Genders, "GenderId", "GenderType", userProfile.GenderTypeId);
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "UserRole", userProfile.UserTypeId);
            return View(userProfile);
        }

        // GET: UserProfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile userProfile = db.UserProfiles.Find(id);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", userProfile.DepartmentId);
            ViewBag.GenderTypeId = new SelectList(db.Genders, "GenderId", "GenderType", userProfile.GenderTypeId);
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "UserRole", userProfile.UserTypeId);
            return View(userProfile);
        }

        // POST: UserProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserProfileId,FirstName,LastName,IdentityNumber,DateOfBirth,GenderTypeId,UserTypeId,PhoneNumber,EmailAddress,PasswordHash,DepartmentId,IsApproved")] UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", userProfile.DepartmentId);
            ViewBag.GenderTypeId = new SelectList(db.Genders, "GenderId", "GenderType", userProfile.GenderTypeId);
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "UserRole", userProfile.UserTypeId);
            return View(userProfile);
        }

        // GET: UserProfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile userProfile = db.UserProfiles.Find(id);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            return View(userProfile);
        }

        // POST: UserProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProfile userProfile = db.UserProfiles.Find(id);
            db.UserProfiles.Remove(userProfile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
