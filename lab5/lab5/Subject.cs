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
        public int Semester { get; set; }
        public string Specialization { get; set; }

        public Subject(string name, string specialization, int semester, int hoursCount)
        {
            HoursCount = hoursCount;
            Name = name;
            Semester = semester;
            Specialization = specialization;
        }

        public override string ToString()
        {
            return $"Przedmiot: {Name} na specjalizacji: {Specialization}, Liczba godzin w {Semester} semestrze: {HoursCount}.";
        }
        public void DisplayInfo()
        {
            Console.WriteLine(this);
        }
    }
}
