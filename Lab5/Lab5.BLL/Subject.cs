using Generic.Extensions;
using System;

namespace Lab5.BLL
{
    public class Subject : IInfo
    {
        public string Name { get; set; }
        public string Specjalization { get; set; }
        public int Semester { get; set; }
        public int HoursCount { get; set; }

        public string CheckFn => Name;

        public Subject(string name, string specjalization, int semester, int hoursCount)
        {
            Name = name;
            Specjalization = specjalization;
            Semester = semester;
            HoursCount = hoursCount;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Specjalization: {Specjalization}, Semester: {Semester}, HoursCount: {HoursCount}";
        }

        public void DisplayInfo()
        {
            Console.WriteLine(this);
        }
    }
}
