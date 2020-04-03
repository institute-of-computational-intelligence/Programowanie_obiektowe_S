using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class FinalGrade :IInfo
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }

        public FinalGrade(Subject subject, double value, DateTime date)
        {
            Value = value;
            Date = date;
        }

        public void ToString()
        {

        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Date: {Date.ToShortDateString()} Value: {Value}");
        }
    }
}
