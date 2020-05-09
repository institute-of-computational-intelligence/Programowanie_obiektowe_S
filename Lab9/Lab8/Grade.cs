using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public class Grade
    {
        public float Value { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }

        public Grade(float value, string subject, DateTime date)
        {
            Value = value;
            Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            Date = date;
        }

        public override string ToString()
        {
            return $"Value:{Value} Subject:{Subject} Date:{Date.ToShortDateString()}\n";
        }
        public Grade() { }
    }
}
