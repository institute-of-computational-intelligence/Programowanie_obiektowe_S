using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public class Student
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int IndexNumber { get; set; }
        public string Faculty { get; set; }
        public IList<Grade> Grades { get; set; }

        public Student(string firstName, string lastName, int index, string faculty)
        {
            FirstName = firstName;
            Surname = lastName;
            IndexNumber = index;
            Faculty = faculty;
            Grades = new List<Grade>();
        }

        public Student()
        {
            FirstName = "";
            Surname = "";
            IndexNumber = 0;
            Faculty = "";
            Grades = new List<Grade>();
        }
    }
}
