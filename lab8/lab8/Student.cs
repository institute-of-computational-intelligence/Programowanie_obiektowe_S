using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Index { get; set; }
        public string Faculty { get; set; }
        public IList<Grades> Grades { get; set; }

        public Student(string name, string lastName, int index, string faculty)
        {
            Name = name;
            Surname = lastName;
            Index = index;
            Faculty = faculty;
            Grades = new List<Grades>();
        }

    public Student()
    {
        Name = "";
        Surname = "";
        Index = 0;
        Faculty = "";
        Grades = new List<Grades>();
    }
}
}
