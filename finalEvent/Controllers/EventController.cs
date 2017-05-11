using finalEvent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace finalEvent.Controllers
{
    public class EventController : Controller
    {
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
                    return RedirectToAction("Sent", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}