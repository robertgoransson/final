using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace finalEvent.Models
{
    public class EventAttendees
    {
        
        [ForeignKey("Event")]
        public int IdEvent { get; set; }

        [ForeignKey("AttendeeEmail")]
        public string Attendes { get; set; }
        public virtual User AttendeeEmail { get; set; }
        public virtual Event Event { get; set; }
    }
}