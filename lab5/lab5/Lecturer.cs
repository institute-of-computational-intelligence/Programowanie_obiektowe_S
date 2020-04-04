using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Lecturer : Person
    {
        public string AcademicTitle { get; set; }
        public string Position { get; set; }

        public Lecturer():
            base()
        {
            AcademicTitle = "";
            Position = "";
        }

        public Lecturer(string fName, string lName, DateTime bDate, string title, string position):
            base(fName, lName, bDate)
        {
            AcademicTitle = title;
            Position = position;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nTytul naukowy: {AcademicTitle}, stanowisko: {Position}";
        }

        public override void DisplayInfo()
        {
            Console.WriteLine(this);
        }
    }
}
