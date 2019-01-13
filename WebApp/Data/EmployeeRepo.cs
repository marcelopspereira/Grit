using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private TriumphDbContext _context = new TriumphDbContext();
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void CreateEmployee(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Repository Error: (DR34). " + ex.Message);
                throw;
            }
        }

        public void DeleteEmployee(Employee employee)
        {
            try
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Repository Error: (DR34). " + ex.Message);
                throw;
            }
        }

        public List<Employee> GetEmployeeById(int EmpID)
        {
            return _context.Employees.Include("EmpID").ToList();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.ToList(); ;
        }

        public void UpdateEmployee(Employee employee)
        {
            try
            {
                _context.Employees.Attach(employee);
                var entry = _context.Entry(employee);
                entry.Property(e => e.FirstName).IsModified = true;
                entry.Property(e => e.LastName).IsModified = true;
                entry.Property(e => e.Email).IsModified = true;
                entry.Property(e => e.Phone).IsModified = true;
                entry.Property(e => e.EnumRoles).IsModified = true;
                entry.Property(e => e.FullName).IsModified = true;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Repository Error: (DR96). " + ex.Message);
                throw;
            }
        }
    }
}
