using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_lab
{
    class Person
    {
        protected string name;
        protected string surname;
        protected string birthDate;

        public Person(string name_, string surname_, string birthDate_)
        {
            name = name_;
            surname = surname_;
            birthDate = birthDate_;
        }

        public virtual void WriteInfo()
        {
            Console.WriteLine( $"Imie {name}, nazwisko {surname}, data urodzenia {birthDate}\n" );
        }
    }
}
