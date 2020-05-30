using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Person : IInfo
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateofBirth { get; set; }


        public Person(string name,string surname,DateTime dateodbirth)
        {
            this.Name = name;
            this.Surname = surname;
            this.DateofBirth = dateodbirth;
        }

        public Person() { }

        public override string ToString()
        {
            return $"Name:{Name} Surname: {Surname} Date of birth: {DateofBirth}";
        }

        public virtual void details()
        {
            Console.WriteLine(this);
        }
    }
}
