using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class FinalGrade
    {
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public Course Coure { get; set; }

        public FinalGrade() { }
        public FinalGrade(double value,DateTime date,Course cours)
        {
            this.Value = value;
            this.Date = date;
            this.Coure = cours;
        }

        public override string ToString()
        {
            return $"Subject: {Coure}, grade: {Value}, date {Date}";
        }

        public void PrintInfo()
        {
            Console.WriteLine(this);
        }
    }
}
