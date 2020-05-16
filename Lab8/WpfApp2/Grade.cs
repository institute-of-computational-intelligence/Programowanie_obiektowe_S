using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class Grade
    {
        public double Value { get; set; }
        public string Subject { get; set; }
        //public DateTime Date { get; set; }

        public Grade(string subject, double value)
        {
            Value = value;
            Subject = subject;
          
        }
    }
}
