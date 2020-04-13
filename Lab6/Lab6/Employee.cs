using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Employee : IInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EmploymentDate { get; set; }

        public Employee(string firstName, string lastName, DateTime birthDate, DateTime employmentDate)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            BirthDate = birthDate;
            EmploymentDate = employmentDate;
        }


        public override string ToString()
        {
            return $"Employee\nFirstname{FirstName} Lastname:{LastName}, Birth date:{BirthDate}, Employment date:{EmploymentDate}\n";
        }


        public virtual void  Details()
        {
            Console.WriteLine(this);
        }
    }
}
