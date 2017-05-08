using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using finalEvent.Models;

namespace finalEvent.Controllers
{
    public class MyPageController : Controller
    {
        
        // GET: MyPage
        public ActionResult Index()
        {
            return View();
        }

        public User GetUser(string Email)
        {
            try
            {
                using (var context = new DbModel())
                {
                    return context.Users.FirstOrDefault(u => u.Email == Email);
                }
            }
            catch
            {
                return null;
            }
        }

        [Authorize]
        public ActionResult MyPage()
        {
            try
            {
                var myUser = User.Identity.Name;
                var Result = GetUser(myUser);
                var model = new User
                {
                    Firstname = Result.Firstname,
                    Lastname = Result.Lastname,
                    Email = Result.Email,
                    Phonenumber = Result.Phonenumber,
                    Picture = Result.Picture,
                    Password = Result.Password
                };

                return View(model);
            }
            catch
            {
                return RedirectToAction("About", "Home");
            }
        }
    }
}