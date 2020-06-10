using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    class FinalGrade : IInfo
    {
        private double grade;
        private string date;
        private Course course;

        public FinalGrade()
        {
            grade = 0;
            date = "--";
        }

        public FinalGrade(double grade_, string date_, Course course_)
        {
            grade = grade_;
            date = date_;
            course = course_;
        }

        public override string ToString()
        {
            return $"Grade: {grade} [{date}]";
        }

        public void Details()
        {
            course.Details();
            Console.WriteLine(this);
        }
    }
}
