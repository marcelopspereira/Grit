using System;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.BusinessLogic
{
    public class EmployeeService : IEmployeeService
    {
        bool IEmployeeService.CreateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        bool IEmployeeService.DeleteEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Employee> IEmployeeService.Employee()
        {
            throw new NotImplementedException();
        }

        Employee IEmployeeService.GetEmployeeById(int EmpID)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Employee> IEmployeeService.GetEmployees()
        {
            throw new NotImplementedException();
        }

        bool IEmployeeService.UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
