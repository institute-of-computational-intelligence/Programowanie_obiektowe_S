using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Lecturer : Person
    {
        public string AcademicTitle { get; set; } = "";
        public string Post { get; set; } = "";

        public Lecturer(string name_, string surname_, string dateOfBirth_, string post_, string academicTitle_) : base(name_, surname_, dateOfBirth_)
        {
            AcademicTitle = academicTitle_;
            Post = post_;
        }

        public override string ToString()
        {
            return base.ToString() + $", Academic title: {AcademicTitle}, Post: {Post}";
        }
    }
}
