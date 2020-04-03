using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Person
    {
        protected string firstName;
        protected string lastName;
        protected DateTime birthDate;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }

        public Person()
        {
            firstName = "none";
            lastName = "none";
            birthDate = new DateTime();
        }
        public Person(string _firstName, string _lastName, DateTime _birthDate)
        {
            firstName = _firstName;
            lastName = _lastName;
            birthDate = _birthDate;
        }
        public override string ToString()
        {
            return $"\nPerson details:\nFirst name: {firstName}, Last name: {lastName}, Date of birth: {birthDate}";
        }
        public virtual void Details()
        {
            Console.WriteLine(this);
        }
    }
}