using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public class Student
    {
        public Student()
        {
            Grades = new List<Grade>();
        }

        public Student(string name, string surname, int index, string subject)
        {
            Name = name;
            Surname = surname;
            Index = index;
            Subject = subject;
            Grades = new List<Grade>();
        }
        public List<Grade> Grades { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Index { get; set; }
        public string Subject { get; set; }


    }
}
