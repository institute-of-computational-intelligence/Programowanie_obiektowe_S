using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Lecturer :Person
    {
        public string AcademicTitle { get; set; }
        public string Position { get; set; }

        public Lecturer()
        {
            AcademicTitle = "none";
            Position = "none";
        }

        public Lecturer(string firstName, string lastName, DateTime dateOfBirth, string academicTitle, string position) 
                        :base(firstName, lastName,dateOfBirth)
        {
            AcademicTitle = academicTitle;
            Position = position;
        }

        public override string ToString()
        {
            return base.ToString() + $"Title: {AcademicTitle}, position: {Position}";
        }
    }
}
