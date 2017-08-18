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
    }
}