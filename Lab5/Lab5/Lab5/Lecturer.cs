using Lab5.Interfaces;
using System;

namespace Lab5
{
    public class Lecturer:Person, IInfo
    {
        public string AcademicTitle { get; set; }
        public string Position { get; set; }

        public Lecturer():base()
        {
            AcademicTitle = "Unknown";
            Position = "Position";
        }

        public Lecturer(string firstName, string lastName, DateTime dateOfBirth,
            string academicTitle, string position)
            :base(firstName, lastName, dateOfBirth)
        {
            AcademicTitle = academicTitle;
            Position = position;
        }

        public override string ToString()
        {
            return base.ToString() +
                $"\nAcademic Title:{AcademicTitle}, Position{Position}";
        }

        public override void DisplayInfo()
        {
            Console.WriteLine(this);
        }
    }
}
