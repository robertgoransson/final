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
                using (var context = new DbModel())
                {
                    {
                        var myUser = User.Identity.Name;
                        if (!context.Contacts.Any(c => c.SenderEmail == myUser && newContact.ReceiverEmail == c.ReceiverEmail))
                        {
                            var friend = new Contact
                            {
                                ReceiverEmail = newContact.ReceiverEmail,
                                SenderEmail = myUser,
                            };
                            context.Contacts.Add(friend);
                            context.SaveChanges();
                            return RedirectToAction("MyContacts", "Contact");
                        }
                        else
                        {
                            return RedirectToAction("AddContact", "Contact");
                        }
                    }
                }   
            }

        public List<Contact> GetContacts()
        {
            try
            {
                using(var context = new DbModel())
                {
                    var myUser = User.Identity.Name;
                    {
                        return context.Contacts.Where(f => f.SenderEmail == myUser).ToList();                       
                    };
                }
            }
            catch
            {
                return null;
            }
        }
        public ActionResult MyContacts()
        {
            var myContacts = GetContacts();
            return View(myContacts);
        }
        public ActionResult DeleteContact(int id)
        {
            try
            {
                using(var context=new DbModel())
                {
                    var deleteContact = context.Contacts.FirstOrDefault(c => c.ContactId == id);
                    context.Contacts.Remove(deleteContact);
                    context.SaveChanges();
                }
                return RedirectToAction("MyContacts", "Contact");
            }
            catch
            {
                return RedirectToAction("Error", "Shared");
            }
        }

      



    }
}