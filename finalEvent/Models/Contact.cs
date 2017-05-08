using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace finalEvent.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [ForeignKey("Sender")]
     
        public string SenderEmail { get; set; }
        [ForeignKey("Receiver")]
       
        public string ReceiverEmail { get; set; }
        
        public bool Accepted { get; set; }
        public virtual User Sender { get; set; }
        public virtual User Receiver { get; set; }
    }
}