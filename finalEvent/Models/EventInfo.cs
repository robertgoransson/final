using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace finalEvent.Models
{
    public class EventInfo : Event
    {

      public EventAttendee EventAttendees { get; set; }
       public Contact Contacts { get; set; }
    }
}