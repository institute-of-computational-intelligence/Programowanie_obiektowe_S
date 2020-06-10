using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Person
    {
        public int Id { get; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }

        static int _id = 101;

        public Person(string firstname, string lastname, int age)
        {
            Id = _id++;
            Firstname = firstname;
            Lastname = lastname;
            Age = age;
        }

        public override string ToString()
        {
            return $"{Firstname} {Lastname} age: {Age} id: {Id}";
        }
    }
}
