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

        public void WriteToFile(StreamWriter stream)
        {
            stream.WriteLine("[[Student]]");
            stream.WriteLine("[Name]");
            stream.WriteLine(Name);
            stream.WriteLine("[Surname]");
            stream.WriteLine(Surname);
            stream.WriteLine("[Department]");
            stream.WriteLine(Dep);
            stream.WriteLine("[IndexNo]");
            stream.WriteLine(IndexNumber);
            stream.WriteLine("[[]]");
        }
    }
}
