using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        [Display(Name = "Name")]
        [PersonalData]
        public string FullName
        {
            get { return (FirstName + " " + LastName); }
        }
        [PersonalData]
        public DateTime DOB { get; set; }
    }
}
