using System;
using System.ComponentModel.DataAnnotations;

namespace Grit.Web.Entities.Invent
{
    public interface IBaseAddress
    {
        [Display(Name = "Street Address 1")]
        [Required]
        [StringLength(50)]
        string street1 { get; set; }

        [Display(Name = "Street Address 2")]
        [StringLength(50)]
        string street2 { get; set; }

        [Display(Name = "City")]
        [StringLength(30)]
        string city { get; set; }

        [Display(Name = "Province")]
        [StringLength(30)]
        string province { get; set; }

        [Display(Name = "Country")]
        [StringLength(30)]
        string country { get; set; }
    }
}
