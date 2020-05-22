using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class FinalGrade : IInfo
    {
        public double Value { get; set; } = 0.0d;
        public string Date { get; set; } = "";
        public Subject Subject { get; set; } = new Subject();

        public FinalGrade(double grade_, string date_, Subject p_)
        {
            Value = grade_;
            Date = date_;
            Subject = p_;
        }

        public void WriteInfo()
        {
            Console.WriteLine($"Grade: {Value}, Date: {Date}, {Subject}");
        }
    }
}
