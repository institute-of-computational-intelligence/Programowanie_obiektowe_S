using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    class Course : IInfo
    {
        private string courseName;
        private string subject;
        private string specialisation;
        private int semester;
        private int hours;

        public string CourseName { get => courseName; set => courseName = value; }

        public Course()
        {
            courseName = "--";
            subject = "--";
            specialisation = "--";
            semester = 0;
            hours = 0;
        }

        public Course(string course_, string subject_, string spec_, int semester_, int hours_)
        {
            courseName = course_;
            subject = subject_;
            specialisation = spec_;
            semester = semester_;
            hours = hours_;
        }

        public override string ToString()
        {
            return $"Course Data| Course: {courseName}, Subject: {subject} [{specialisation}]\r\n\tSemester: {semester}, Number of hours: {hours}";
        }

        public void Details()
        {
            Console.WriteLine(this);
        }
    }
}
