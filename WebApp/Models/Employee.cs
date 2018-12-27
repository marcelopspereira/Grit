using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Employee     {         [Key]         public int EmpID { get; set; }          [Display(Name = "FirstName")]         public string FirstName { get; set; }          [Display(Name = "LastName")]         public string LastName { get; set; }          [Display(Name = "Name")]         public string FullName         {             get { return (FirstName + " " + LastName); }         }          public string Email { get; set; }         public string Phone { get; set; }         public string Notes { get; set; }

        public IEnumerable<Role> Roles { get; set; }
        public IEnumerable<Project> Projects { get; set; }

        [NotMapped]
        public class Role
        {
            [Display(Name = "Lead Developer")]
            public Role LeadDev { get; set; }
            [Display(Name = "Developer")]
            public Role Dev { get; set; }
            public Role Sales { get; set; }
            public Role Admin { get; set; }
            public Role Manager { get; set; }
        }
    } }