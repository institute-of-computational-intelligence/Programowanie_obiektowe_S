using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Faculty { get; set; }
        public int IndexNumber { get; set; }
        public IList<Grade> Grades { get; }

        public Student() {
            Grades = new List<Grade>();
        }

        public Student(string name, string surname, string faculty, int index)
        {
            Name = name;
            Surname = surname;
            Faculty = faculty;
            IndexNumber = index;

            Grades = new List<Grade>();
        }

        public override string ToString()
        {
            return $"Name: {Name}, surname {Surname}, Faculty: {Faculty}, Index number: {IndexNumber}";
        }

        public void PrintInfo()
        {
            Console.WriteLine(this);
        }

        public void AddGrade(Grade grade)
        {
            Grades?.Add(grade);
        }
    }
}
