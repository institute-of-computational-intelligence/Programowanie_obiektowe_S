using System;
using Generic.Extensions;

namespace Lab5.BLL
{
    public class FinalGrade : IInfo
    {
        public Subject Subject { get; set; }

        public DateTime Date { get; set; }

        public double Value { get; set; }

        public FinalGrade(Subject subject, double value, DateTime date)
        {
            Date = date;
            Subject =subject;
            Value = value;
        }

        public override string ToString()
        {
            return $"Grade: {Value}, Subject: {Subject}, Date: {Date}";
        }

        public void DisplayInfo()
        {
            Console.WriteLine(this);
        }

    }
}
