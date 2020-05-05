using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class Grade
    {
        public float Value { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }

        public Grade(float value, string subject, DateTime date)
        {
            Value = value;
            Subject = subject;
            Date = date;
        }

        public Grade()
        { }
    }
}
