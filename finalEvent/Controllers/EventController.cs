using finalEvent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using finalEvent.Controllers;

namespace finalEvent.Controllers
{
    public class EventController : Controller
    {
        MyPageController _myPageController = new MyPageController();
        // GET: Event
        [HttpGet]
        public ActionResult CreateEvent()
        {
            return View();
        }
        [HttpPost]

        public ActionResult CreateEvent(Event newEvent)
        {
            using (var context = new DbModel())
            {
                if (!context.Events.Any(e => e.EventId == newEvent.EventId))
                {
                    var events = new Event
                    {
                        EventName = newEvent.EventName,
                        Description = newEvent.Description,
                        StartDate = newEvent.StartDate,
                        StartHour = newEvent.StartHour,
                        EndingDate = newEvent.EndingDate,
                        EndHour = newEvent.EndHour,
                        Location = newEvent.Location,
                        Owner = User.Identity.Name.ToString()



                    };
                    context.Events.Add(events);
                    context.SaveChanges();
                    return RedirectToAction("Sent", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }

          public List<Event> GetEvents()
        {
            try
            {
                using (var context = new DbModel())
                {
                    var myUser = User.Identity.Name;
                    {   
                        return context.Events.Where(e => e.Owner == myUser).ToList(); 
                    }
                }
            }
            catch
            {
                return null;
            }
        }       
        public ActionResult MyEvents()
        {          
            ViewBag.Event = GetEvents().Select(e => e.EventName).ToList();
            return View();
        }
    }
}