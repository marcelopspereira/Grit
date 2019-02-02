using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class INetcoreBasic
    {
        [Display(Name = "Created At")]
        public DateTime createdAt { get; set; } = DateTime.UtcNow;
    }
}
