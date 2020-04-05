using System;
using Lab5.Interfaces;

namespace Lab5
{
    public class Person : IInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Person()
        {
            FirstName = "Unknown";
            LastName = "Unknown";
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
            return $"FirstName:{FirstName} LastName:{LastName} Date:{DateOfBirth}";
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine(this);
        }

    }
}
