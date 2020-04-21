using System;
using Generic.Extensions;

namespace Lab5.BLL
{
    public class Lecturer : Person, IInfo
    {
        public string AcademicTitle { get; set; }
        public string Position { get; set; }
        

        public Lecturer(string firstName, string lastName, DateTime dateOfBirth, string academicTitle, string position)
            :base(firstName, lastName, dateOfBirth)
        {
            Position = position;
            AcademicTitle = academicTitle;
        }

        public override string ToString()
        {
            return base.ToString() + $" Academic Title: {AcademicTitle}, Position: {Position}";
        }
    }
}
