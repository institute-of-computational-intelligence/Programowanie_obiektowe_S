using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    public class Grade
    {
        public float Value { get; set; }
        public string Subject { get; set; }

        public Grade()
        {
            Value = 0;
            Subject = null;
        }
        public Grade(float value, string subject)
        {
            Value = value;
            Subject = subject;
        }
    }
}
