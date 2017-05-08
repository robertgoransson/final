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
                var request = new Friend
                {
                    Accepted = false,
                    FirstUID = receiverId,
                    SecondUID = userId,

                };

                context.Friends.Add(request);
                context.Friends.Add(friend);
                context.SaveChanges();
            }

            return View();
        }
    }
}