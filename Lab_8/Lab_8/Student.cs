using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Dep { get; set; }
        public int IndexNumber { get; set; }

        public List<Grade> Grades { get; set; }

        public Student()
        {
            Grades = new List<Grade>();
        }

        public Student(string name, string surname, int indexNumber, string dep)
        {
            Name = name;
            Surname = surname;
            Dep = dep;
            IndexNumber = indexNumber;
            Grades = new List<Grade>();
        }
    }
}
