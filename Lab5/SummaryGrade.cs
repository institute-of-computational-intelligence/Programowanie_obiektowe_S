using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class SummaryGrade:IInfo
    {
        private double value = 0.0;
        private string date = "";
        private Course course;

        public SummaryGrade()
        {
        }

        public SummaryGrade(double value, string date, Course course)
        {
            this.value = value;
            this.date = date;
            this.course = course;
        }

        public double Value { get => value; set => this.value = value; }
        public string Date { get => date; set => date = value; }
        internal Course Course { get => course; set => course = value; }

        public void Details()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return $"Ocena: {value}, {date}";
        }
    }
}
