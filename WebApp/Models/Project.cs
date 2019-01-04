using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Project     {         public int ID { get; set; }
        [Display(Name = "Project Title")]         public string Name { get; set; }
        [Display(Name = "Due Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]         public DateTime DueDate { get; set; }         public string Attributes { get; set; }         public string Priority { get; set; }

        [ForeignKey("Client")]
        [Display(Name = "Assigned Client")]         public int AssignedClientID { get; set; }
        public Client Client { get; set; }

        [ForeignKey("Employee")]
        [Display(Name = "Assigned Employee")]
        public int EmployeeID { get; set; }
        public Employee FullName { get; set; }
    } }
