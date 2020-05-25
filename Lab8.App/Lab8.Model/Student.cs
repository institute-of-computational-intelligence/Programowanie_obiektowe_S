using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab8.Model.Attributes;

namespace Lab8.Model
{
    public class Student
    {
        public int StudentNo { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string  Faculty { get; set; }
        [SerializationIgnore]
        public List<Grade> Grades { get; set; }

        [SerializationIgnore]
        public string JoinedGrades => string.Join(", ", Grades);

        public Student()
        {
            Grades = new List<Grade>();
        }
    }
}
