using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Invent
{
    public class BaseSocialMedia
    {
        [Display(Name = "Blog")]
        [StringLength(100)]
        public string blog { get; set; }

        [Display(Name = "Website")]
        [StringLength(100)]
        public string website { get; set; }

        [Display(Name = "Linkedin")]
        [StringLength(100)]
        public string linkedin { get; set; }
    }
}
