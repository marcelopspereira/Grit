using System;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.Data
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private TriumphDbContext _context = new TriumphDbContext();
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void CreateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Employee()
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(int EmpID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
