using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using finalEvent.Models;
using System.IO;

namespace finalEvent.Controllers
{
    public class MyPageController : Controller
    {

        // GET: MyPage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EditUser()
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




        [Authorize]
        [HttpPost]
        public ActionResult EditUser(User user, string Email, HttpPostedFileBase file)
        {
            try
            {
                using (var context = new DbModel())
                {
                    User myUser = context.Users.FirstOrDefault(u => u.Email == Email);
                    if(user != null)
                    {
                        myUser.Picture = Path.GetFileName(file.FileName);
                        myUser.Firstname = user.Firstname;
                        myUser.Lastname = user.Lastname;
                        myUser.Password = user.Password;
                        myUser.ConfirmPassword = user.ConfirmPassword;
                        myUser.Phonenumber = user.Phonenumber;                        
                    }
                    else
                    {
                        return null;
                    }
                    context.SaveChanges();
                    return RedirectToAction("Mypage", "Mypage");
                }
            }
            catch
            {
                return RedirectToAction("EditUser", "Mypage");
            }
        }

        public void ProfilePicture(string file)
        {
            try
            {
                using (var db = new DbModel())
                {
                    var email = User.Identity.Name;
                    User users = db.Users.FirstOrDefault(u => u.Email == email);
                    users.Picture = file;
                    db.SaveChanges();
                }
            }
            catch
            {
                
            }
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditPicture( HttpPostedFileBase file)
        {
            try
            {
                using (var context = new DbModel())
                {
                    var Email = User.Identity.Name;
                    User myUser = context.Users.FirstOrDefault(u => u.Email == Email);
                    if (file != null)
                    {
                        string picture = System.IO.Path.GetFileName(file.FileName);
                        string path = System.IO.Path.Combine(Server.MapPath("~/images/profile"), picture);
                        file.SaveAs(path);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            file.InputStream.CopyTo(ms);
                            byte[] array = ms.GetBuffer();
                        }
                        context.SaveChanges();
                        return RedirectToAction("MyPage", "MyPage");
                    }
                    else
                    {
                        return null;
                    }
                    
                }
            }
            catch
            {
                return RedirectToAction("MyPage", "MyPage");
            }
        }
    }
}