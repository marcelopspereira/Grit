using System;
using System.ComponentModel.DataAnnotations;

namespace Grit.Web.Entities.Invent
{
    public interface IBasePerson
    {
        [Display(Name = "First Name")]
        [Required]
        [StringLength(20)]
        string firstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(20)]
        string lastName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(20)]
        string middleName { get; set; }

        [Display(Name = "Nick Name")]
        [StringLength(20)]
        string nickName { get; set; }

        [Display(Name = "Gender")]
        Gender gender { get; set; }

        [Display(Name = "Salutation")]
        Salutation salutation { get; set; }
    }


}
