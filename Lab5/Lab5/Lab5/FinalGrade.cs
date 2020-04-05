using System;
using Lab5.Interfaces;

namespace Lab5
{
    public class FinalGrade:IInfo
    {
        public FinalGrade(Subject subject, double value, DateTime date)
        {
            Subject = subject;
            Value = value;
            Date = date;
        }

        public void DisplayInfo()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return $"Subject:{Subject}, Value:{Value}, Date:{Date}";
        }

        public Subject Subject { get; }
        public double Value { get; }
        public DateTime Date { get; }
    }
}