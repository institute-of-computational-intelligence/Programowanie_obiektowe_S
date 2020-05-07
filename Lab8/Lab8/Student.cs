using System;

namespace Lab8
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Faculty { get; set; }
        public int IndexNo { get; set; }

        public Student()
        { }

        public Student(string name, string surname, int indexNo, string faculty)
        {
            Name = name;
            Surname = surname;
            IndexNo = indexNo;
            Faculty = faculty;
        }
    }
}
