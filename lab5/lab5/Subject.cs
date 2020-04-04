using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Subject : IInfo
    {
        public int HoursCount { get; set; }
        public string Name { get; set; }
        public int Semestr { get; set; }
        public string Specjalization { get; set; }

        
        public Subject (string name, string specjalization, int semestr, int hoursCount)
        {
            Name = name;
            Specjalization = specjalization;
            Semestr = semestr;
            HoursCount = hoursCount;
        }
        public override string ToString()
        {
            return $"Przedmiot: {Name} na specjalizacji: {Specjalization}, Liczba godzin w {Semestr} semestrze: {HoursCount}.";
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine(this);
        }


    }
}
