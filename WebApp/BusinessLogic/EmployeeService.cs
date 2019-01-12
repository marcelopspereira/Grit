using System;
using System.Collections.Generic;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.BusinessLogic
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepo _empRepo;
        private IValidationDictionary _validation;
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public EmployeeService(IEmployeeRepo projRepo, IValidationDictionary validation)
        {
            _empRepo = projRepo;
            _validation = validation;
        }

        public bool CreateEmployee(Employee employee)
        {
            if (!ValidateEmp(employee))
                return false;

            try
            {
                _empRepo.CreateEmployee(employee);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Service Error:  (DS48). " + ex.Message);
                throw;
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            if (!ValidateEmp(employee))
                return false;

            try
            {
                _empRepo.UpdateEmployee(employee);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Service Error:  (DS48). " + ex.Message);
                throw;
            }
        }

        public bool DeleteEmployee(Employee employee)
        {
            try
            {
                _empRepo.DeleteEmployee(employee);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Service Error:  (DS139). " + ex.Message);
                throw;
            }
        }

        public IEnumerable<Employee> Employee()
        {
            return _empRepo.Employee();
        }

        public Employee GetEmployeeById(int EmpID)
        {
            return _empRepo.GetEmployeeById(EmpID);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _empRepo.GetEmployees();
        }

        public bool ValidateEmp(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
