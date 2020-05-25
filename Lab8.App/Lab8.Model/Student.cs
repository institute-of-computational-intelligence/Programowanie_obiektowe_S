using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Model
{
    public class Student
    {
        public int StudentNo { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string  Faculty { get; set; }
        public IList<Grade> Grades { get; set; }

        public string JoinedGrades => string.Join(", ", Grades);

        public Student()
        {
            Grades = new List<Grade>();
        }
    }
}
