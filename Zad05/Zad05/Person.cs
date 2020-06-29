using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad05 {
    public class Person : IInfo {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public DateTime BirthDate { get; protected set; }
        public Person(string firstName, string lastName, DateTime birthDate) {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public override string ToString() {
            return $"{FirstName} {LastName} {BirthDate.ToShortDateString()} ";
        }
        public virtual void DisplayInfo() {
            Console.WriteLine(this);
        }
    }
}
