using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data;
using finalEvent.Models;

namespace finalEvent.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(string Email, string password)
        {
            using (var context = new DbModel())
            {
                var user = context.Users.FirstOrDefault(u => u.Email.Equals(Email) && u.Password.Equals(password));
                if (user != null)
                    return RedirectToAction("About", "Home");
            }
            return RedirectToAction("Contact","Home");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}


