using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Subject : IInfo
    {
        public int HoursCount { get; set; }
        public string Name { get; set; }
        public int Semestr { get; set; }
        public string Specialization { get; set; }

        public Subject(string name, string specialization, int semestr, int hoursCount)
        {
            HoursCount = hoursCount;
            Name = name;
            Semestr = semestr;
            Specialization = specialization;
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return $"Subject name: {Name} Specialization: {Specialization} Semester: {Semestr} Hours: {HoursCount}";
        }

    }
}
