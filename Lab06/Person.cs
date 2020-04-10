using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06
{
    class Person : IInfo
    {

        public string Name { get; set; }
        public string Surname { get; set; }

        public Person(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            return $"Person: {Name} {Surname}";
        }

        public void DisplayInfo()
        {
            Console.WriteLine(this);
        }
    }
}
