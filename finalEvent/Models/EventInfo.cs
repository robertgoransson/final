using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace finalEvent.Models
{
    public class EventInfo:Event
    {
      

        public IEnumerable<Contact> MyContacts { get; set; }
        
    }
}