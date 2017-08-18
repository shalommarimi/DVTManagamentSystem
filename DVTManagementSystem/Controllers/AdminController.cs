using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DVTManagementSystem.Models;
using DVTManagementSystem.Migrations;
using DVTManagementSystem.Models.Context;

namespace DVTManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        DVTManagementSystemContext DVTcontext = new DVTManagementSystemContext();
        // GET: Admin
        public ActionResult UserList()
        {
            var users= DVTcontext.UserProfiles.ToList();
            return View(users);
        }
    }
}