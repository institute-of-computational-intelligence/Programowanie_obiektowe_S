using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Lecturer : Person
    {
        public string Position { get; }
        public string AcademicTitle { get; }
     
        public Lecturer(string name, string surname, DateTime birthday,
            string position, string academicTitle)
            : base(name, surname, birthday)
        {
            Utilities.CheckNullOrWhitespace(position);
            Utilities.CheckNullOrWhitespace(academicTitle);

            Position = position;
            AcademicTitle = academicTitle;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Position: {Position}\nAcademic title: {AcademicTitle}");
            Console.WriteLine();
        }
    }
}
