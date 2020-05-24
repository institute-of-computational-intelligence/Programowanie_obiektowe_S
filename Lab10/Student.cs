using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    [DBTab]
    public class Student
    {
        [DBColl(Title = "Name")]
        public string Name { get; set; }
        [DBColl(Title = "Surname")]
        public string Surname { get; set; }
        [DBColl(Title = "Student Index Number")]
        public int IndexNumber { get; set; }
        [DBColl(Title = "Major")]
        public string Major { get; set; }

        public Student() { }

        public Student(string name_, string surname_, int indexNumber_, string major_)
        {
            Name = name_;
            Surname = surname_;
            IndexNumber = indexNumber_;
            Major = major_;
        }

        public Student(Student student_)
        {
            Name = student_.Name;
            Surname = student_.Surname;
            IndexNumber = student_.IndexNumber;
            Major = student_.Major;
        }
    }
}
