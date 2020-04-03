using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Grade
    {
        private string subjectName;
        private DateTime date;
        private double value_;

        public string SubjectName { get => subjectName; set => subjectName = value; }
        public DateTime Date { get => date; set => date = value; }
        public double Value_ { get => value_; set => value_ = value; }

        public Grade()
        {
            subjectName = "none";
            date = new DateTime();
            value_ = 0.0;
        }

        public Grade(string _subjectName, DateTime _date, double _value_)
        {
            subjectName = _subjectName;
            date = _date;
            value_ = _value_;
        }
        public override string ToString()
        {
            return $"Subject name: {subjectName}, Date: {date}, Value: {value_}";
        }
        public void Details()
        {
            Console.WriteLine(this);
        }
    }
}