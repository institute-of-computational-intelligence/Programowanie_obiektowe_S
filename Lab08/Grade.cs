using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08
{
    public class Grade
    {
        public string Subject { get; }
        public int GradeValue { get; }

        public Grade(string subject, int grade)
        {
            this.Subject = subject;
            this.GradeValue = grade;
        }
    }
}
