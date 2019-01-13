using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models
{
    public class Employee     {         [Key]         public int EmpID { get; set; }          [Display(Name = "First Name")]         public string FirstName { get; set; }          [Display(Name = "Last Name")]         public string LastName { get; set; }          [Display(Name = "Name")]         public string FullName         {             get { return (FirstName + " " + LastName); }         }          public string Email { get; set; }         public string Phone { get; set; }

        [Display(Name = "Roles")]
        public EmpRole EnumRoles { get; set; }
        public enum EmpRole
        {
            LeadDev,
            Dev,
            Sales,
            Admin,
            Manager,
        }
    }
} 