using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Person : IInfo
    {
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


     
        public Person()
        {
            
        }
        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}, urodzony: {DateOfBirth}";
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine(this);
        }
    }
}
