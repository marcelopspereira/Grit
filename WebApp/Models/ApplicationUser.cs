using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Models
{
    public partial class ApplicationUser : IdentityUser
    {
        public string profilePictureUrl { get; set; } = "/images/empty_profile.png";
        public bool isSuperAdmin { get; set; } = false;


        [Display(Name = "Roles")]
        public bool ApplicationUserRole { get; set; } = false;
    }
}
