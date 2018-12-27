using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models
{
    public class Employee     {         [Key]         public int EmpID { get; set; }          [Display(Name = "FirstName")]         public string FirstName { get; set; }          [Display(Name = "LastName")]         public string LastName { get; set; }          [Display(Name = "Name")]         public string FullName         {             get { return (FirstName + " " + LastName); }         }          public string Email { get; set; }         public string Phone { get; set; }         public string Notes { get; set; }
        public IEnumerable<Project> Projects { get; set; }

        public Roles EnumRoles { get; set; }
        public enum Roles
        {
            LeadDev,
            Dev,
            Sales,
            Admin,
            Manager,
        }
    }
} 