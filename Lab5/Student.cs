using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Student : Person
    {
        public string Major { get; set; } = "";
        public string Speciality { get; set; } = "";
        public int Year { get; set; } = 0;
        public int Group { get; set; } = 0;
        public int IndexNumber { get; set; } = 0;
        public List<FinalGrade> Grades { get; set; } = new List<FinalGrade>();

        public Student(string name_, string surname_, string dateOfBirth_, string major_, string speciality_, int year_, int group_, int indexNumber_) : base(name_, surname_, dateOfBirth_)
        {
            Major = major_;
            Speciality = speciality_;
            Year = year_;
            Group = group_;
            IndexNumber = indexNumber_;
        }

        public override string ToString()
        {
            return base.ToString() + $", Subject: {Major}, Speciality: {Speciality}, Year: {Year}, Group: {Group}, Index number: {IndexNumber}";
        }

        public void InfoGrades()
        {
            foreach(FinalGrade x in Grades)
            {
                x.WriteInfo();
            }
        }

        public void AddGrade(Subject subject, double grade, string date)
        {
            Grades.Add(new FinalGrade(grade, date, subject));
        }
    }
}
