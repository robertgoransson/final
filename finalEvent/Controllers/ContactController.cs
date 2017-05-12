using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using finalEvent.Models;
using finalEvent.Helpers;

namespace finalEvent.Controllers
{
    public class ContactController : Controller
    {
        FriendHelper _friendHelper = new FriendHelper();
        // GET: Friend
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult AddContact()
        {
            return View();
        }

        //public User GetUser(string Email)
        //{
        //    try
        //    {
        //        using (var context = new DbModel())
        //        {
        //            return context.Users.FirstOrDefault(u => u.Email == Email);
        //        }
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        [HttpPost]
        public ActionResult AddContact(Contact newContact)
        {
            try
            {
                using (var context = new DbModel())
                {
                    {


                        var friend = new Contact
                        {
                            ReceiverEmail = newContact.ReceiverEmail,
                            SenderEmail = User.Identity.Name                            
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
        }
    }
}