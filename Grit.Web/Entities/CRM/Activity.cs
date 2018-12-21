using System;
using System.ComponentModel.DataAnnotations;

namespace Grit.Web.Entities.CRM
{
    public class Activity : INetcoreBasic
    {
        public Activity()
        {
            this.createdAt = DateTime.UtcNow;
        }

        [StringLength(38)]
        [Display(Name = "Activity Id")]
        public string activityId { get; set; }

        [StringLength(50)]
        [Display(Name = "Activity Name")]
        [Required]
        public string activityName { get; set; }

        [StringLength(50)]
        [Display(Name = "Activity Description")]
        public string description { get; set; }

        [StringLength(10)]
        [Display(Name = "Color Hex")]
        public string colorHex { get; set; }
    }
}

