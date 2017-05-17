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
 

        public ActionResult Created()
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
                        Address = newEvent.Address,
                        Owner = User.Identity.Name.ToString()



                    };
                    context.Events.Add(events);
                    context.SaveChanges();
                    return RedirectToAction("MyEvents", "Event");
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


        public List<EventAttendee> GetAttendees(int id)
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

        public ActionResult Delete(int id)
        {
            try
            {
                using (var context = new DbModel())
                {

                    var deleteEvent = context.Events.First(e => e.EventId == id);


                    context.Events.Remove(deleteEvent);
                    context.SaveChanges();
                }
                return RedirectToAction("MyEvents", "Event");

            }
            catch
            {
                return RedirectToAction("Error", "Shared");
            }

        }

        public ActionResult ShowEvent(int id)
        {
           
            var eventID = id;
            try {
                using (var context = new DbModel())
                {
                    var events = context.Events.Where(e => e.EventId == eventID).FirstOrDefault();
                    
                    
                      
                    
                    var eventinfo = new EventInfo
                    {
                        EventName = events.EventName,
                        Description = events.Description,
                        StartDate = events.StartDate,
                        EndingDate = events.EndingDate,
                        StartHour = events.StartHour,
                        EndHour = events.EndHour,
                        Owner = events.Owner,
                        Address = events.Address
                       
                        
                    };
                    return View(eventinfo);
                }

            }
            catch
            {
                return RedirectToAction("MyEvents", "Events");
            }
        }
        [HttpGet]
        public ActionResult MyContactss()
        {
            ContactController _Cc = new ContactController();
            var myContacts = _Cc.GetContacts();
            return View(myContacts);
        }
    }
}