using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class Lecturer : Person
    {
        public string AcademicTitle { get; set; }
        public string Position { get; set; }


        public Lecturer(string name, string surname, DateTime birthDate, string academicTitle, string position) : base(name, surname, birthDate)
        {
            Position = position;
            AcademicTitle = academicTitle;
        }

        public override string ToString()
        {
            return base.ToString() + $", academic title {AcademicTitle}, position: {Position}";
        }

        public override void PrintInfo()
        {
            Console.WriteLine(this);
        }
    }
}
