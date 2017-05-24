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
        [RegularExpression(@"^(?=.*\d)(?=.*[a-zåäöA-ZÅÄÖ]).{5,15}$", ErrorMessage ="Lösen ska vara minst fem tecken långt, högst 15 tecken långt och ska innehålla minst en siffra och minst en bokstav.")]
        [StringLength(15, MinimumLength = 5)]
        
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