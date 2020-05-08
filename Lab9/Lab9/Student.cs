using System;
using System.Collections.Generic;
using System.IO;

namespace Lab9
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Faculty { get; set; }
        public int IndexNo { get; set; }

        public Student()
        {
        }

        public Student(string name, string surname, int indexNo, string faculty)
        {
            Name = name;
            Surname = surname;
            IndexNo = indexNo;
            Faculty = faculty;
        }

        public void WriteToFile(StreamWriter streamWriter)
        {
            streamWriter.WriteLine("[[Student]]");
            streamWriter.WriteLine("[Name]");
            streamWriter.WriteLine(Name);
            streamWriter.WriteLine("[Surname]");
            streamWriter.WriteLine(Surname);
            streamWriter.WriteLine("[Faculty]");
            streamWriter.WriteLine(Faculty);
            streamWriter.WriteLine("[IndexNo]");
            streamWriter.WriteLine(IndexNo);
            streamWriter.WriteLine("[[]]");
        }
    }
}
