using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    class Person
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }

        public Person(string name,string surname,int age)
        {
            this.Name = name;
            this.SurName = surname;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{Name} {SurName} age:{Age}";
        }
    }
}
