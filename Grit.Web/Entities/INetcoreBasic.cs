using System;
using System.ComponentModel.DataAnnotations;

namespace Grit.Web.Entities
{
    public class INetcoreBasic
    {
        [Display(Name = "Created At")]
        public DateTime createdAt { get; set; } = DateTime.UtcNow;
    }
}

