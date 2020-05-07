﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Subject : IInfo
    {
        public string Name { get; }
        public string Specialization { get; }
        public int Semester { get; }
        public int HourCount { get; }

        public Subject(string name, string specialization, int semester, int hourCount)
        {
            Utilities.CheckNullOrWhitespace(name);
            Utilities.CheckNullOrWhitespace(specialization);

            Name = name;
            Specialization = specialization;
            Semester = semester;
            HourCount = hourCount;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Subject name: {Name} Specialization: {Specialization}");
            Console.WriteLine($"Semester: {Semester} Hours: {HourCount}");
            Console.WriteLine();
        }
    }
}