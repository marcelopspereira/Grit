using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Crm
{
    public class LeadLine : INetcoreBasic
    {
        public LeadLine()
        {
            this.createdAt = DateTime.UtcNow;
            this.startDate = DateTime.UtcNow;
            this.endDate = this.startDate.AddDays(1);
        }

        [StringLength(38)]
        [Display(Name = "Lead Line Id")]
        public string leadLineId { get; set; }

        [StringLength(38)]
        [Display(Name = "Lead")]
        public string leadId { get; set; }

        [Display(Name = "Lead")]
        public Lead lead { get; set; }

        [StringLength(38)]
        [Display(Name = "Activity")]
        public string activityId { get; set; }

        [Display(Name = "Activity")]
        public Activity activity { get; set; }

        [Display(Name = "Start Date")]
        public DateTime startDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime endDate { get; set; }

        [StringLength(200)]
        [Display(Name = "Activity Description")]
        [Required]
        public string description { get; set; }
    }
}
