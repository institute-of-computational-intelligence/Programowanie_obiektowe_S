using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06
{
    class Employee : IInfo
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; protected set; }
        public DateTime HireDate { get; protected set; }

        public Employee(string name, string surname, DateTime dateOfBirth, DateTime hireDate)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            HireDate = hireDate;
        }

        public override string ToString()
        {
            return $"Employee: {Name} {Surname}";
        }

        public void DisplayInfo()
        {
            Console.WriteLine(this);
        }
    }
}
