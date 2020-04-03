using System;
using System.Collections.Generic;
using System.Text;
using Lab5.Interfaces;

namespace Lab5
{
    class Student : Person, IInfo
    {
        public int Group { get; }
        public int IndexId { get;  }
        public string Specialization { get; }
        public int Year { get; }

        public List<FinalGrade> Grades;    

        public Student(string name, string surname, DateTime birthday, string specialization, int year, int group, int indexNo)
            : base(name, surname, birthday)
        {
            Utilities.CheckNullOrWhitespace(specialization);

            Specialization = specialization;
            Year = year;

            Group = group;

            IndexId = indexNo;

            Grades = new List<FinalGrade>();

        }

        public void AddGrade(FinalGrade grade)
        {
            Utilities.CheckNull(grade);

            Grades.Add(grade);
        }
        public void AddGrade(Subject subject, double value, DateTime date)
        {
            Utilities.CheckNull(subject);

            Grades.Add(new FinalGrade(subject, value, date));
        }
        public void DeleteGrades()
        {
            Grades.Clear();
        }

        public bool DeleteGrade(FinalGrade grade)
        {
            Utilities.CheckNull(grade);
            
            return Grades.Remove(grade);
        }

        public void DisplayGrades()
        {
            Console.WriteLine("Grades:");
            foreach (var grade in Grades)
            {
                grade.PrintInfo();
            }
            Console.WriteLine();
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Specialization: {Specialization} Year: {Year}" +
                $"Group: {Group} IndexId: {IndexId}\n");
        }
    }
}
