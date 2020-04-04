using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class FinalGrade : IInfo
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public Subject Subject { get; set; }

        public FinalGrade(Subject subject, double value, DateTime date)
        {
            Value = value;
            Date = date;
            Subject = subject;
        }

        public override string ToString()
        {
            return $"Ocena: {Value} otrzymana {Date} z przedmiotu: {Subject}";
        }
        public void DisplayInfo()
        {
            Console.WriteLine(this);
        }
    }
}
