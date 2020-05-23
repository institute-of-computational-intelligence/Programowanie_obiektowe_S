﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int IndexNumber { get; set; }
        public string Major { get; set; }

        public Student(string name_, string surname_, int indexNumber_, string major_)
        {
            Name = name_;
            Surname = surname_;
            IndexNumber = indexNumber_;
            Major = major_;
        }

        public Student() { }

        public Student(Student student_)
        {
            Name = student_.Name;
            Surname = student_.Surname;
            IndexNumber = student_.IndexNumber;
            Major = student_.Major;
        }
    }
}
