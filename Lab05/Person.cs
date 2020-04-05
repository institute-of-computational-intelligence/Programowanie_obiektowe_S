using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class Person : IInfo
    {
        protected string name;
        protected string surname;
        protected DateTime birthDate;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        protected DateTime BirthDate { get => birthDate; set => birthDate = value; }

        public Person(string name, string surname, DateTime birthDate)
        {
            this.name = name;
            this.surname = surname;
            this.birthDate = birthDate;
        }

        public Person()
        {
            name = "";
            surname = "";
            birthDate = new DateTime();
        }

        public override string ToString()
        {
            return $"Person: {name} {surname}, birth date {birthDate}";
        }

        public virtual void PrintInfo()
        {
             Console.WriteLine(this);
        }
    }
}
