using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Web;
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations.Schema;

namespace finalEvent.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        [Required(ErrorMessage ="Eventet måste ha ett namn.")]
        
        public string EventName { get; set; }
    
        public DateTime StartDate  { get; set; }
        public DateTime EndingDate { get; set; }
       
        public DateTime StartHour { get; set;  }
        public DateTime EndHour { get; set; }
        public string  Description { get; set; }
        public DbGeography Location { get; set; }
          [ForeignKey("Email")]
        public string Owner { get; set; }
     
        public virtual User Email { get; set;  }



        
    

    }
}