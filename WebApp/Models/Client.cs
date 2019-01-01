using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Client     {         [Key]         public int ClientID { get; set; }         [Display(Name = "Business")]         public string BusinessName { get; set; }         public string Email { get; set; }         public string Phone { get; set; }         [Display(Name = "First Name")]         public string FirstName { get; set; }         [Display(Name = "Last Name")]         public string LastName { get; set; }          [Display(Name = "Business ID")]         public string DisplayName { get; set; }          [Display(Name = "Name")]         public string FullName         {             get { return (FirstName + " " + LastName); }         }          [Display(Name = "Assigned Too")]         public virtual ICollection<Employee> EmpFullName { get; set; }

        public virtual ICollection<Note> Notes { get; set; }

     } }

