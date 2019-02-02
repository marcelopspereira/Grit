using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.AccountViewModel
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
