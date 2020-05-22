using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Subject
    {
        public string Name { get; set; } = "";
        public string Major { get; set; } = "";
        public string Speciality { get; set; } = "";
        public int Semester { get; set; } = 0;
        public int HoursCount { get; set; } = 0;

        public Subject()
        {
            Name = "";
            Major = "";
            Speciality = "";
            Semester = 0;
            HoursCount = 0;
        }

        public Subject(string name_, string major_, string speciality_, int semester_, int hoursCount_)
        {
            Name = name_;
            Major = major_;
            Speciality = speciality_;
            Semester = semester_;
            HoursCount = hoursCount_;
        }

        public override string ToString()
        {
            return $"Subject name: {Name}, Major: {Major}, Speciality: {Speciality}, Semester: {Semester}, Hours count: {HoursCount}";
        }
    }
}
