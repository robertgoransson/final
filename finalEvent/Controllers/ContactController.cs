using finalEvent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace finalEvent.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddContact(string senderEmail, string receiverEmail)
        {
            using (var context = new DbModel())
            {
                var contact = new Contact
                {
                    Accepted = true,
                    SenderEmail = senderEmail,
                    ReceiverEmail = receiverEmail

                };
                var request = new Contact
                {
                    Accepted = false,
                    SenderEmail = senderEmail,
                    ReceiverEmail = receiverEmail

                };

                context.Contacts.Add(request);
                context.Contacts.Add(contact);
                context.SaveChanges();
            }

            return View();
        }
    }
}