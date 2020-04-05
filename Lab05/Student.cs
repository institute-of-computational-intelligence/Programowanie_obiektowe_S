using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class Student : Person
    {
        public string FieldOfStudy { get; set; }
        public string Speciality { get; set; }
        public int Year { get; set; }
        public int Group { get; set; }
        public int IndexNumber { get; set; }
        private IList<FinalGrade> Grades { get; }

        public Student(string name, string surname, DateTime birthDate, string fieldOfStudy, string speciality, int year, int group, int indexNumber) : base(name, surname, birthDate)
        {
            FieldOfStudy = fieldOfStudy;
            Speciality = speciality;
            Year = year;
            Group = group;
            IndexNumber = indexNumber;

            Grades = new List<FinalGrade>();
        }

        public override string ToString()
        {
            return base.ToString() + $", field of study: {FieldOfStudy}, speciality {Speciality}, year of study: {Year}, group { Group}, index number {IndexNumber}";
        }

        public override void PrintInfo()
        {
            Console.WriteLine(this);
        }

        public void PrintGrades()
        {
            foreach (FinalGrade gr in Grades)
                Console.WriteLine(gr);
        }

        public void AddGrade(Subject subject, double grade, DateTime date)
        {
            bool hasGrade = false;
            foreach (FinalGrade gr in Grades)
                if (gr.Subject.Equals(subject)) {
                    hasGrade = true;
                    break;
                }

            if (!hasGrade)
                Grades.Add(new FinalGrade(grade, date, subject));
        }
    }
}
