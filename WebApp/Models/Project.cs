using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class Project     {         public int ID { get; set; }         public string Name { get; set; }         public DateTime DueDate { get; set; }         public string Attributes { get; set; }         public string Priority { get; set; }         public Client AssignedClientID { get; set; }
         public class EmployeeList
        {
            public List<Employee> Employees { get; set; }
        }

        public class ClientList
        {
            public List<Client> Clients { get; set; }
        }
    } }
