using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class Student
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public int NoIndex { get; set; }
        public string Department  { get; set; }
        public List <Grade> Grades { get; set; }

        
        public Student(string name, string surname, int noIndex, string department)
        {
            Name = name;
            Surname = surname;
            NoIndex = noIndex;
            Department = department;
            Grades = new List<Grade>();
        }

        public Student()
        {
            Grades = new List<Grade>();

        }
       

    }
}
