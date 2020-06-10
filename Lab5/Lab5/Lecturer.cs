using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    class Lecturer : Person
    {
        private string title;
        private string job;

        public Lecturer():
            base()
        {
            title = "--";
            job = "--";
        }

        public Lecturer(string name_, string surname_, string date_, string title_, string job_) :
            base(name_, surname_, date_)
        {
            title = title_;
            job = job_;
        }

        public override string ToString()
        {
            return base.ToString() + $"\r\nLecturer Data| Title: {title}, Job: {job}";
        }

        public override void Details()
        {
            Console.WriteLine(this);
            Console.WriteLine("\r\n");
        }
    }
}
