using System;
using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace WebApp.ViewModel
{
    public class ProjectVM
    {
        public int ID { get; set; }
        [Display(Name = "Project Title")]
        public string Name { get; set; }
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }
        public string Attributes { get; set; }
        public string Priority { get; set; }
        [Display(Name = "Client Assigned")]
        public Client AssignedClientID { get; set; }
        [Display(Name = "Employees Assigned")]
        public Employee EmployeeID { get; set; }
        [Display(Name = "Employee Names")]
        public Employee EmpFullName { get; set; }
    }
}
