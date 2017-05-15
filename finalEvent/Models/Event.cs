using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Web;
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI;

namespace finalEvent.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        [Required(ErrorMessage ="Eventet måste ha ett namn.")]
        
        public string EventName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string  StartDate  { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string EndingDate { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh/mm}", ApplyFormatInEditMode = true)]
        public string StartHour { get; set;  }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh/mm}", ApplyFormatInEditMode = true)]
        public DateTime EndHour { get; set; }
        public string  Description { get; set; }
     
        public string Address { get; set; }
        [ForeignKey("Email")]
        public string Owner { get; set; }
     
        public virtual User Email { get; set; }



        
    

    }
}