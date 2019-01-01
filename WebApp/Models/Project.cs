using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Project     {         public int ID { get; set; }         public string Name { get; set; }         public DateTime DueDate { get; set; }         public string Attributes { get; set; }         public string Priority { get; set; }

        [ForeignKey("Client")]         public int AssignedClientID { get; set; }
        public Client Client { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public Employee FullName { get; set; }
    } }
