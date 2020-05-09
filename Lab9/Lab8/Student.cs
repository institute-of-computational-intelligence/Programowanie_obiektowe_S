using System;
using System.Collections.Generic;
using System.IO;
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
       // public IList<Grade> Grades { get; set; }

        public Student(string firstName, string lastName, int index, string faculty)
        {
            FirstName = firstName;
            Surname = lastName;
            IndexNumber = index;
            Faculty = faculty;
            //Grades = new List<Grade>();
        }

        public Student()
        {
            FirstName = "";
            Surname = "";
            IndexNumber = 0;
            Faculty = "";
           // Grades = new List<Grade>();
        }

       

        public void SaveToFile(StreamWriter streamWriter)
        {
            streamWriter.WriteLine("[[Student]]");
            streamWriter.WriteLine("[FirstName]");
            streamWriter.WriteLine(FirstName);
            streamWriter.WriteLine("[Surname]");
            streamWriter.WriteLine(Surname);
            streamWriter.WriteLine("[IndexNumber]");
            streamWriter.WriteLine(IndexNumber);
            streamWriter.WriteLine("[Faculty]");
            streamWriter.WriteLine(Faculty);
            streamWriter.WriteLine("[Grades]");
            //foreach (var grade in Grades)
            //{
            //    streamWriter.Write(grade.ToString());
            //}
            streamWriter.WriteLine("[[]]");
        }

        public bool CheckValue()
        {
            if (Faculty == "" && FirstName == "" && IndexNumber == 0 && Surname == "")
                return false;
            return true;
        }
    }
}
