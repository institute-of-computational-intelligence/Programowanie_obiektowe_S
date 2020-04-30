using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_lab
{
    class Student : Person
    {
        private int year;
        private int group;
        private int indexNr;

        public Student(string name_, string surname_, string birthDate_, int year_, int group_, int indexNr_) :
            base(name_, surname_, birthDate_)
        {
            year = year_;
            group = group_;
            indexNr = indexNr_;
        }

        public override void WriteInfo()
        {
            Console.WriteLine($"Imie {name}, nazwisko {surname}, data urodzenia {birthDate}");
            Console.WriteLine($"Rok studiow {year}, grupa {group}, numer indeksu {indexNr}\n");
        }
    }
}