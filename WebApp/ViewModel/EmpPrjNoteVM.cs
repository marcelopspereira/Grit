using System;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.ViewModel
{
    public class EmpPrjNoteVM
    {
        //Employee Info
        Employee EmpID { get; set; }
        Employee FullName { get; set; }
        Employee Email { get; set; }
        Employee Phone { get; set; }
        Employee EnumRoles { get; set; }

        public List<Project> Projectss { get; set; }

        //Employee Notes
        EmployeeNote EmpTitle { get; set; }
        EmployeeNote Content { get; set; }
    }
}
