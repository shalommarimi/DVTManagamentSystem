using DVTManagementSystem.Models;
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



                    var user = context.UserProfiles.Single(u => u.EmailAddress == profile.EmailAddress && u.PasswordHash == profile.PasswordHash && u.IsApproved == true);
                    if (user != null)
                    {

                        Session["FirstName"] = user.FirstName.ToString();
                        Session["LastName"] = user.FirstName.ToString();
                        return RedirectToAction("Dashboard", "Applicant");

                    }


                }
                catch (System.Exception)
                {
                    ModelState.AddModelError(string.Empty, "Username or Password is incorrect");

                }
            }


            return View();
        }
    }
}