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

        [EmailAddress(ErrorMessage = "E-post måste ha format Exempel@test.se")]
        [StringLength(40)]
        public string Email { get; set; }

        [Required]
        [DataType("Password")]
        [RegularExpression(@"^(?=.*[a-zåäö])(?=.*[A-ZÅÄÖ])(?=.*\d)[a-zA-Z\d]{6,}$", ErrorMessage ="Lösen ska vara minst fem tecken långt och ska innehålla Stor bokstav, liten bokstav och minst en siffra.")]
        [StringLength(20, MinimumLength = 6)]
        
        public string Password { get; set; }

        [DataType("Password")]
        [Compare("Password", ErrorMessage = "Lösenorden matchar inte.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"^[a-zåäöA-ZÅÄÖ]+$", ErrorMessage ="Förnamn får endast innehålla bokstäver.")]
        [StringLength(20)]
        public string Firstname { get; set; }

        [Required]
        [RegularExpression(@"^[a-zåäöA-ZÅÄÖ]+$", ErrorMessage = "Efternamn får endast innehålla bokstäver.")]
        [StringLength(25)]
        public string Lastname { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage ="Telefonummer får endast innehålla siffror.")]
        public string Phonenumber { get; set; }

        public string Picture { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }

    }
}