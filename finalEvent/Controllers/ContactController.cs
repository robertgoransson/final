using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using finalEvent.Models;

namespace finalEvent.Controllers
{
    public class ContactController : Controller
    {
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
                            SenderEmail = User.Identity.Name,
                            Accepted = false
                        };
                        var friend2 = new Contact
                        {
                            ReceiverEmail = User.Identity.Name,
                            SenderEmail = newContact.SenderEmail,
                            Accepted = false
                        };

                        context.Contacts.Add(friend);
                        context.Contacts.Add(friend2);
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

        public List <Contact> FriendRequest(string email)
        {
                using(var context = new DbModel())
                {
                var friendRequest = context.Contacts.Where(f => f.SenderEmail == email && f.Accepted == false).Select(f => f.SenderEmail).ToList();
                return context.Contacts.Where(u => friendRequest.Any(f => f==u.ReceiverEmail)).ToList();
                }
        }

        public void Accepted(string email)
        {
            using (var context = new DbModel())
            {
                context.Contacts.FirstOrDefault(f => f.ReceiverEmail == User.Identity.Name && f.SenderEmail == email).Accepted = true;
                context.SaveChanges();
            }
        }
        public List<Contact> GetFriends()
        {
            try
            {
                using(var context = new DbModel())
                {
                    var myUser = User.Identity.Name;
                    {
                        return context.Contacts.Where(f => f.SenderEmail == myUser && f.Accepted == true).ToList();                       
                    };
                }
            }
            catch
            {
                return null;
            }
        }
        public ActionResult ShowContacts()
        {
            var myContacts = GetFriends();
            return View(myContacts);
        }
        
    }
}