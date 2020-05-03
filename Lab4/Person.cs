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
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        static int _id = 101;

        public Person(string Name, string Surname, int Age)
        {
            this.Id = _id++;
            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;
        }

        public override string ToString() => $"{Name} {Surname} Age: {Age} Id: {Id}";
    }
}
