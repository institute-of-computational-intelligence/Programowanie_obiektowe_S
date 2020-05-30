using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_8
{
    public class Student
    {
        public string SurName { get; set; }
        public string FristName { get; set; }
        public int StudentNo { get; set; }
        public string Faculty { get; set; }

        public Student() { }
        public Student(string SurName, string FristName, int StudentNo, string Faculty)
        {
            this.SurName = SurName;
            this.FristName = FristName;
            this.StudentNo = StudentNo;
            this.Faculty = Faculty;
        }
    }
}
