using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    class Lecturer: Person
    {
        public string Position { get; }
        public string AcademicTitle { get; set; }

        public Lecturer(string name,string surname,DateTime birthday, string position, string academicTitle)
            : base(name,surname,birthday)
        {
            Utilities.CheckNullOrWhitespace(position);
            Utilities.CheckNullOrWhitespace(academicTitle);

            Position = position;
            AcademicTitle = academicTitle;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Position: {Position}\n Academic title: {AcademicTitle}");
            Console.WriteLine();
        }
    }
}
