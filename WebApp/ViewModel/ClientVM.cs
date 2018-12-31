using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace WebApp.ViewModel
{
    public class ClientVM
    {
        [Key]
        public int ClientID { get; set; }
        [Display(Name = "Business")]
        public string BusinessName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Business ID")]
        public string DisplayName { get; set; }

        [Display(Name = "Name")]
        public string FullName
        {
            get { return (FirstName + " " + LastName); }
        }

        [Display(Name = "Employee Assigned")]
        public List<Employee> Assigned { get; set; }
    }
}
