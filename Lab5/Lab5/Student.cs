using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Student : Person, IInfo
    {
        public string Specialization { get; }
        public int Year { get; }
        public int Group { get; }
        public int IndexNo { get; }

        public List<FinalGrade> Grades;

        public Student(string name, string surname, DateTime birthday,
              string specialization, int year, int group, int indexNo)
            : base(name, surname, birthday)
        {
            Utilities.CheckNullOrWhitespace(specialization);

            Specialization = specialization;
            Year = year;
            Group = group;
            IndexNo = indexNo;
            Grades = new List<FinalGrade>();
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Specialization: {Specialization} Year: {Year}");
            Console.WriteLine($"Group: {Group} Index No.: {IndexNo}");
            Console.WriteLine();
        }

        public void PrintMarksInfo()
        {
            Console.WriteLine("Grades:");
            foreach (var mark in Grades)
            {
                mark.PrintInfo();
            }
            Console.WriteLine();
        }

        public void AddGrade(Subject subject, double mark, DateTime date)
        {
            Utilities.CheckNull(subject);

             Grades.Add(new FinalGrade(subject, mark, date));
        }

        public void AddGrade(FinalGrade finalGrade)
        {
            Utilities.CheckNull(finalGrade);

            Grades.Add(finalGrade);
        }

        public bool DeleteGrade(FinalGrade finalGrade)
        {
            Utilities.CheckNull(finalGrade);

            return Grades.Remove(finalGrade);
        }

        public void DeleteGrades()
        {
            Grades.Clear();
        }
    }
}
