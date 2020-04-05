using System;
using Lab5.Interfaces;

namespace Lab5
{
    public class Subject : IInfo
    {
        public int HoursCount { get; set; }
        public string Name { get; set; }
        public int Semester { get; set; }
        public string Specialization { get; set; }


        public Subject()
        {
            HoursCount = 0;
            Name = "Unknown";
            Semester = 0;
            Specialization = "Unknown";
        }

        public Subject(string name, string specialization, int semester, int hoursCount)
        {
            HoursCount = hoursCount;
            Name = name;
            Semester = semester;
            Specialization = specialization;
        }

        public override string ToString()
        {
            return $"Name:{Name}, Specialization:{Specialization}, Semester:{Semester}, Hours:{HoursCount}";
        }

        public void DisplayInfo()
        {
            Console.WriteLine(this);
        }
    }
}