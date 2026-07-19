using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ZooManagementSystem
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name  { get; set; } = string.Empty;
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public EmployeeRole  EmployeeRole { get; set; }
        public double Salary { get; set; }
        public DateTime JoiningDate { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;

    }
}
