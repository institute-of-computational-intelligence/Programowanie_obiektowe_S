using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class Subject : IInfo
    {
        public string Name { get; set; }
        public string FieldOfStudy { get; set; }
        public string Speciality { get; set; }
        public int Semester { get; set; }
        public int Hours { get; set; }

        public Subject(string name, string fieldOfStudy, string speciality, int semester, int hours)
        {
            Name = name;
            FieldOfStudy = fieldOfStudy;
            Speciality = speciality;
            Semester = semester;
            Hours = hours;
        }

        public override string ToString()
        {
            return $"Subject name: {Name}, field of study {FieldOfStudy}, speciality {Speciality}, semester {Semester}, hours {Hours}";
        }

        public void PrintInfo()
        {
            Console.WriteLine(this);
        }
    }
}
