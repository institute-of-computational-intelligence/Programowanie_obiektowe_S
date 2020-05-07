using System;
using System.Collections.Generic;

namespace Lab8
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Faculty { get; set; }
        public int IndexNo { get; set; }
        public List<Grade> Grades { get; set; }

        public Student()
        {
            Grades = new List<Grade>();
        }

        public Student(string name, string surname, int indexNo, string faculty)
        {
            Name = name;
            Surname = surname;
            IndexNo = indexNo;
            Faculty = faculty;
            Grades = new List<Grade>();
        }
    }
}
