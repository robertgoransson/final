using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace finalEvent.Models
{
    public class EventInfo : Event
    {


        public System.Web.Mvc.SelectList MyContacts { get; set; }
        public Contact Contacts
        {
            get; set;


        }
    }
}