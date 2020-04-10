using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Person :IInfo
    {
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person()
        {
            FirstName = "";
            LastName = "";
            DateOfBirth = new DateTime();
        }

        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, date of birth: {DateOfBirth}";
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine(this);
        }
    }
}
