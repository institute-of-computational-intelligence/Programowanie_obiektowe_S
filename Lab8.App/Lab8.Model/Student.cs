using System;
using Lab8.Model.Attributes;
using System.Collections.Generic;

namespace Lab8.Model
{
    [DbTab]
    public class Student
    {
        [DbCol]
        public int StudentNo { get; set; }
        [DbCol]
        public string FirstName { get; set; }
        [DbCol]
        public string SurName { get; set; }
        [DbCol]
        public string Faculty { get; set; }
        [DbCol]
        public DateTime DateOfBirth { get; set; }
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
