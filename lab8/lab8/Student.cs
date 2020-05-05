using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IndexNo { get; set; }
        public string Faculty { get; set; }

        public List<Grade> Grades;
        public Student()
        {
            FirstName = null;
            LastName = null;
            IndexNo = 0;
            Faculty = null;
            Grades = new List<Grade>();
        }
        public Student(string firstName, string lastName, int indexNo, string faculty, List<Grade> grades)
        {
            FirstName = firstName;
            LastName = lastName;
            IndexNo = indexNo;
            Faculty = faculty;
            Grades = grades;
        }
        
    }
}
