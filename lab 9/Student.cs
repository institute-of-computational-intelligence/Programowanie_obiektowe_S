using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Dep { get; set; }
        public int IndexNumber { get; set; }
        public Student()
        {

        }
        public Student(string name, string surname, int indexNumber, string dep)
        {
            Name = name;
            Surname = surname;
            Dep = dep;
            IndexNumber = indexNumber;
        }

        public Student(Student student_)
        {
            Name = student_.Name;
            Surname = student_.Surname;
            IndexNumber = student_.IndexNumber;
            Dep = student_.Dep;
        }
    }
}