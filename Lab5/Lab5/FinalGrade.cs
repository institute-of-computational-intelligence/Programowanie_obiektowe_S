using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class FinalGrade : IInfo
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public Subject Subject { get; set; }

        public FinalGrade(Subject subject, double value, DateTime date)
        {
            Subject = subject;
            Value = value;
            Date = date;
        }

        public override string ToString()
        {
            return $"Date: {Date.ToShortDateString()} Value: {Value}\n";
        }

        public void DisplayInfo()
        {
            Console.WriteLine(this);
        }
    }
}
