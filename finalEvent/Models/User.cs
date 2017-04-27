using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace finalEvent.Models
{
    public class User
    {
        [Key]
        [StringLength(40)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [Required]
        [StringLength(20)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(25)]
        public string Lastname { get; set; }

        [Required]
        public string Phonenumber { get; set; }

        public string Picture { get; set; }
    }
}