using System;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.ViewModel
{
    public class EmployeeVM
    {
        public Employee emp { get; set; }
        public List<int> SelectedEmp { get; set; }

        public virtual List<Employee> Employees { get; set; }

        public EmployeeVM()
        {

        }

        public EmployeeVM(Employee _emp, List<Employee> _Emp)
        {
            emp = _emp;
            Employees = _Emp;
            SelectedEmp = new List<int>();
        }
    }
}
