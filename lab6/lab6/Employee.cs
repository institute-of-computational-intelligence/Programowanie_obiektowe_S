using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab6
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime DismissDate { get; set; }
        public Employee(string firstName, string lastName, DateTime hireDate, DateTime dismissDate)
        {
            FirstName = firstName;
            LastName = lastName;
            HireDate = hireDate;
            DismissDate = dismissDate;
        }
    }
}