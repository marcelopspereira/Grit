using System;
using System.ComponentModel.DataAnnotations;
using Grit.Web.Entities.Invent;

namespace Grit.Web.Entities.CRM
{
    public class AccountExecutive : INetcoreBasic, IBaseAddress
    {
        public AccountExecutive()
        {
            this.createdAt = DateTime.UtcNow;
        }

        [StringLength(38)]
        [Display(Name = "Account Executive Id")]
        public string accountExecutiveId { get; set; }

        [StringLength(50)]
        [Display(Name = "Account Executive Name")]
        [Required]
        public string accountExecutiveName { get; set; }

        [StringLength(50)]
        [Display(Name = "Account Executive Description")]
        public string description { get; set; }

        [Display(Name = "Phone")]
        [StringLength(50)]
        public string phone { get; set; }

        [Display(Name = "Email")]
        [StringLength(50)]
        public string email { get; set; }

        //IBaseAddress
        [Display(Name = "Street Address 1")]
        [Required]
        [StringLength(50)]
        public string street1 { get; set; }

        [Display(Name = "Street Address 2")]
        [StringLength(50)]
        public string street2 { get; set; }

        [Display(Name = "City")]
        [StringLength(30)]
        public string city { get; set; }

        [Display(Name = "Province")]
        [StringLength(30)]
        public string province { get; set; }

        [Display(Name = "Country")]
        [StringLength(30)]
        public string country { get; set; }
        //IBaseAddress

        [Display(Name = "Related System User")]
        [StringLength(38)]
        public string systemUserId { get; set; }
    }
}
