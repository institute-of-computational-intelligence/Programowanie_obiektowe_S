using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Student : Person
    {
        private int year;
        private int group;
        private int indexId;
        private List<Grade> grades = new List<Grade>();

        public int Year { get => year; set => year = value; }
        public int Group { get => group; set => group = value; }
        public int IndexId { get => indexId; set => indexId = value; }

        public Student() : base()
        {
            year = 0;
            group = 0;
            indexId = 0;
        }
        public Student(string firstName, string lastName, DateTime birthDate, int _year, int _group, int _indexId) : base(firstName, lastName, birthDate)
        {
            year = _year;
            group = _group;
            indexId = _indexId;
        }
        public void AddGrade(string subjectName, DateTime date, double value)
        {
            Grade grade = new Grade(subjectName, date, value);
            grades.Add(grade);
        }
        public void DisplayGrades()
        {
            foreach (Grade grade in grades)
            {
                grade.Details();
            }
        }
        public void DisplayGrade(string subjectName)
        {
            foreach (Grade grade in grades)
            {
                if (subjectName == grade.SubjectName) { grade.Details(); }
            }
        }
        public void RemoveGrade(string subjectName, DateTime date, double value)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                if (grades[i].SubjectName == subjectName && grades[i].Date == date && grades[i].Value_ == value) { grades.RemoveAt(i); }
            }
        }
        public void RemoveGrade(string subjectName)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                if (grades[i].SubjectName == subjectName) { grades.RemoveAt(i); }
            }
        }
        public void RemoveGrades()
        {
            grades.Clear();
        }
        public override string ToString()
        {
            return base.ToString() + $"\nYear: {year}, Group: {group}, Index ID: {indexId}";
        }
        public override void Details()
        {
            Console.WriteLine(this);
        }


    }
}