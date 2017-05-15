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
                        return context.Events.Where(e => e.Owner == myUser).OrderBy(e => e.StartDate).ToList(); 
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
            var myEvents = GetEvents();
            return View(myEvents);

        }

        public List <EventAttendee> GetAttendees(int id)
        {
            try
            {
                using (var context = new DbModel())
                {
                    var eventID = id;
                    {
                        return context.EventAttendees.Where(e => e.IdEvent == eventID).ToList();
                    }
                }
            }
            catch
            {
                return null;
            }
        }
        public ActionResult Attendee(int id)
        {
            var att = GetAttendees(id);
            return View(att);
        }
        //public ActionResult Attendee(int id)
        //{
        //    try
        //    {
        //        using (var context = new DbModel())
        //        {
        //            var myEvent = id;
        //            {
        //                return context.EventAttendees.f
        //            }
        //        }
        //    }
        //}
    }
}