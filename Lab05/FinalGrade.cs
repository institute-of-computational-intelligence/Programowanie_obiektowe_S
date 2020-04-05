using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class FinalGrade : IInfo
    {
        public double Grade { get; set; }
        public DateTime Date { get; set; }
        public Subject Subject { get; set; }

        public FinalGrade(double grade, DateTime date, Subject subject)
        {
            Grade = grade;
            Date = date;
            Subject = subject;
        }

        public override string ToString()
        {
            return $"Subject: {Subject}, grade: {Grade}, date {Date}";
        }

        public void PrintInfo()
        {
            Console.WriteLine(this);
        }
    }
}
