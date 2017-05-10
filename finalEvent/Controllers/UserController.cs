using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data;
using finalEvent.Models;
using System.IO;

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
        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        

        public ActionResult Login(string Email, string password)
        {
            using (var context = new DbModel())
            {

                var user = context.Users.FirstOrDefault(u => u.Email.Equals(Email) && u.Password.Equals(password));

                if (user != null && ModelState.IsValid)
                {
                    HttpCookie cookie = new HttpCookie("Email");
                    cookie[Email] = Email;
                    Response.Cookies.Add(cookie);
                    FormsAuthentication.SetAuthCookie(Email, true);


                    return RedirectToAction("About", "Home");
                }
                else
                {

                    return View();
                }
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        public User Search(string Epost)
        {
            using (var context = new DbModel())
            {

                return context.Users.Where(u => u.Email == Epost).FirstOrDefault();
            }
        }

        public ActionResult showInfo(string Epost)
        {
            try
            {
                var result = Search(Epost);
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
                return RedirectToAction("About", "Home");
            }
        }
        [HttpPost]
        public ActionResult RegisterUser(User newUser, HttpPostedFileBase file)
        {
            

            try
            {
            
                
                using (var context = new DbModel())
                {
                   
                    if (!context.Users.Any(u => u.Email == newUser.Email))
                    {
                        var user = new User
                        {
                            Picture = Path.GetFileName(file.FileName),

                            Email = newUser.Email,
                            Password = newUser.Password,
                            Firstname = newUser.Firstname,
                            Lastname = newUser.Lastname,
                            Phonenumber = newUser.Phonenumber,
                         
                            ConfirmPassword = newUser.Password
                        };
                        
                        context.Users.Add(user);
                        context.SaveChanges();
                        
                        return RedirectToAction("About","Home");
                    }
                    
                    
                }
           

                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }




            return View();
        }
        //public ActionResult FileUpload(HttpPostedFileBase file)
        //{

        //    if (file != null)
        //    {
        //       DbModel db = new DbModel();
        //        string ImageName = System.IO.Path.GetFileName(file.FileName);
        //        string physicalPath = Server.MapPath("~/Images/" + ImageName);

        //        // save image in folder
        //        file.SaveAs(physicalPath);

        //        //save new record in database
        //        var userPicture = new User();
        //        userPicture.Picture = ImageName;
        //        db.Users.Add(userPicture);
        //        db.SaveChanges();

        //    }
        //    //Display records
        //    return View();
        //}


        //public ActionResult UploadPicture(HttpPostedFileBase file)
        //{
        //    if (file != null)
        //    {
        //        string pic = Path.GetFileName(file.FileName);
        //        string path =Path.Combine(
        //                               Server.MapPath("~/images/profile"), pic);

        //        file.SaveAs(path);


        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            file.InputStream.CopyTo(ms);
        //            byte[] array = ms.GetBuffer();
        //        }

        //    }

        //    return View();
        //}


    }
}
