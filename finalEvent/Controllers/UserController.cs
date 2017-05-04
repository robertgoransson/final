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
                {
                    HttpCookie cookie = new HttpCookie("email");
                    cookie[Email] = Email;
                    Response.Cookies.Add(cookie);


                    return RedirectToAction("About", "Home");
                }
                else
                {

                    return RedirectToAction("Contact", "Home");
                }
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        public User Search(string Email)
        {
            using (var context = new DbModel())
            {

                return context.Users.Where(u => u.Email == Email).FirstOrDefault();
            }
        }

        public ActionResult showInfo(string Email)
        {
            try
            {
                var result = Search(Email);
                var model = new User
                {
                    Firstname = result.Firstname,
                    Lastname = result.Lastname,
                    Picture = result.Picture
                };
                return View(model);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
