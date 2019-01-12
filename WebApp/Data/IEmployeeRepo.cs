using System;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.Data
{
    public interface IEmployeeRepo
    {
        IEnumerable<Employee> Employee();
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(int EmpID);
        void CreateEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
