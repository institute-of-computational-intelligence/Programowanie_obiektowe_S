using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Extensions;

namespace Lab6.BLL
{
    public abstract class Employee : IInfo
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public DateTime DateOfBirth { get; protected set; }

        public DateTime HireDate { get; protected set; }

        public Employee(string firstName, string lastName, DateTime dateOfBirth, DateTime hireDate)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            HireDate = hireDate;
        }

        public override string ToString()
        {
            return $"Person data | First name: {FirstName}, Last name: {LastName}, Date of Birth: {DateOfBirth}, Hire date: {HireDate}";
        }

        public virtual void Display()
        {
            Console.WriteLine(this);
        }
    }


}
