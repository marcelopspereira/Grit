using System;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.ViewModel
{
    public class EmployeeVM
    {
        //Employee Data
        public Employee EmpID { get; set; }
        public Employee FullName { get; set; }
        public Employee Email { get; set; }
        public Employee Phone { get; set; }
        public Employee EnumRole { get; set; }

        //Project Data
        public Project PID { get; set; }
        public Project Name { get; set; }
        public Project DueDate { get; set; }
        public Project AssignedClientID { get; set; }

        //Note Data
        public Note NID { get; set; }
        public Note Title { get; set; }
        public Note Content { get; set; }

        public IEnumerable<Employee> GetEmployees {get;set;}
    }
}
