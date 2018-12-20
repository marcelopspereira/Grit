using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Grit.Web.Entities
{     public class Employee     {         [Key]         public int EmpID { get; set; }          [Display(Name = "FirstName")]         public string FirstName { get; set; }          [Display(Name = "LastName")]         public string LastName { get; set; }          [Display(Name = "Name")]         public string FullName         {             get { return (FirstName + " " + LastName); }         }          public string Email { get; set; }         public string Phone { get; set; }         public string Notes { get; set; }



        public class ProjectList
        {
            public List<Project> Projects { get; set; }
        }     } }