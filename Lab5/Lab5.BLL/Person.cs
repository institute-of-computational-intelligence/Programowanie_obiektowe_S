using System;
using Generic.Extensions;

namespace Lab5.BLL
{

    public class Person : IInfo
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public DateTime DateOfBirth { get; protected set; }
        

        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {DateOfBirth.ToShortDateString()} ";
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine(this);
        }
    }
}
