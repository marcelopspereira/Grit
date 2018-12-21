using System;
using System.ComponentModel.DataAnnotations;

namespace Grit.Web.Entities.CRM
{
    public class OpportunityLine : INetcoreBasic
    {
        public OpportunityLine()
        {
            this.createdAt = DateTime.UtcNow;
            this.startDate = DateTime.UtcNow;
            this.endDate = this.startDate.AddDays(1);
        }

        [StringLength(38)]
        [Display(Name = "Opportunity Line Id")]
        public string opportunityLineId { get; set; }

        [StringLength(38)]
        [Display(Name = "Opportunity")]
        public string opportunityId { get; set; }

        [Display(Name = "Opportunity")]
        public Opportunity opportunity { get; set; }

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
