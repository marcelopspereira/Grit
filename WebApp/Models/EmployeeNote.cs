using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class EmployeeNote
    {
        [Key]
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Employee EmpID { get; set; }
    }
}
