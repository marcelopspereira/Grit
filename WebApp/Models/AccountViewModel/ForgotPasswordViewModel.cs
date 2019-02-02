using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.AccountViewModel
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
