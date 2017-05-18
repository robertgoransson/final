using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Threading.Tasks;
using finalEvent.Models;
using System.Web.Helpers;
using finalEvent.Controllers;
namespace finalEvent.Controllers
{
    public class EmailController : Controller
    {
        UserController _userController = new UserController();

        public EmailController()
        {
            _userController = new UserController();
        }
             
        public ActionResult SendEmail() {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendEmail(string email)
        {




            if (ModelState.IsValid)
            {



                var user = User.Identity.Name;
                using (var context = new DbModel())
                {
                    var firstname=context.Users .Where(e => e.Email == user).Select(e => e.Firstname).SingleOrDefault();
                    var lastname= context.Users.Where(e => e.Email == user).Select(e => e.Lastname).SingleOrDefault();





                    var body = "<p>Inbjudan från:{0} {1}</br>Kul! Nu har även du lyckats bli inbjuden till ett evenemang din populäre jäkel. Följ länken nedan</p></br> <a href=\"http://www.grabbhelg.nu/\">Till Evenemanget</a>";

                var message = new MailMessage();
                message.To.Add(new MailAddress(email));
                message.From = new MailAddress(this.User.Identity.Name);
                message.Subject = "Inbjudan till event";
                message.Body = string.Format(body,firstname,lastname);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new System.Net.NetworkCredential
                    {
                        UserName = "Eventplaneraren@gmail.com",
                        Password = "goransson"
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent", "Home");
                }


            }
        }

                    return View();

            }

        } 

    
}