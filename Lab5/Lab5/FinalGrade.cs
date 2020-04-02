using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class FinalGrade : IInfo
    {
        public Subject Subject { get; }
        public double Value { get; }
        public DateTime Date { get; }

        public FinalGrade(Subject subject, double value, DateTime date)
        {
            Utilities.CheckNull(subject);

            Subject = subject;
            Value = value;
            Date = date;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Subject: {Subject.Name} Mark: {Value} Date: {Date.ToShortDateString()}");
        }
    }
}
