using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Id { get; }

        static int id = 101;

        public Person(string fName, string lName, int age)
        {
            FirstName = fName;
            LastName = lName;
            Age = age;
            Id = id++;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, lat: {Age}, ID: {Id}";
        }
    }
}
