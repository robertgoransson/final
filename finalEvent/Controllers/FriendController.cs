using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using finalEvent.Models;

namespace finalEvent.Controllers
{
    public class FriendController : Controller
    {
        // GET: Friend
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

        [HttpPost]
        public ActionResult AddContact(Contact newContact1)
        {
            try
            {
                using (var context = new DbModel())
                {

                    if (!context.Contacts.Any(u => u.ReceiverEmail == newContact1.ReceiverEmail))
                    {
                        
                        var myUser = User.Identity.Name;
                        var user = GetUser(myUser);
                        var friend = new Contact
                        {
                            SenderEmail = user.Email,
                            ReceiverEmail = newContact1.SenderEmail
                        };

                        context.Contacts.Add(friend);
                        context.SaveChanges();

                        return RedirectToAction("About", "Home");
                    }
                }
            }
            catch 
            {
                return null;
            }
            return View();
        }
    }
}