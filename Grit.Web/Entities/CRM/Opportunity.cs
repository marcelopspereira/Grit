using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Grit.Web.Entities.CRM
{
    public class Opportunity : INetcoreMasterChild
    {
        public Opportunity()
        {
            this.createdAt = DateTime.UtcNow;
            this.estimatedRevenue = 0m;
            this.estimatedClosingDate = DateTime.UtcNow.AddMonths(1);
        }

        [StringLength(38)]
        [Display(Name = "Opportunity Id")]
        public string opportunityId { get; set; }

        [StringLength(50)]
        [Display(Name = "Opportunity Name")]
        [Required]
        public string opportunityName { get; set; }

        [StringLength(50)]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Stage")]
        [StringLength(38)]
        public string stageId { get; set; }
        [Display(Name = "Stage")]
        public Stage stage { get; set; }

        [Display(Name = "Account Executive")]
        [StringLength(38)]
        public string accountExecutiveId { get; set; }

        [Display(Name = "Account Executive")]
        public AccountExecutive accountExecutive { get; set; }

        [Display(Name = "Customer")]
        [StringLength(38)]
        public string customerId { get; set; }

        [Display(Name = "Customer")]
        public Customer customer { get; set; }

        [Display(Name = "Estimated Revenue")]
        public decimal estimatedRevenue { get; set; }

        [Display(Name = "Estimated Closing Date")]
        public DateTime estimatedClosingDate { get; set; }

        [Display(Name = "Probability (%)")]
        public int probability { get; set; }

        [Display(Name = "Rating")]
        [StringLength(38)]
        public string ratingId { get; set; }

        [Display(Name = "Rating")]
        public Rating rating { get; set; }

        [Display(Name = "Activities")]
        public List<OpportunityLine> opportunityLine { get; set; } = new List<OpportunityLine>();
    }
}
