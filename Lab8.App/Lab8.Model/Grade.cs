using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Model
{
    public class Grade
    {
        public DateTime DateOfIssue  { get; set; }
        public float GradeValue { get; set; }
        public override string ToString()
        {
            return GradeValue.ToString(CultureInfo.InvariantCulture);
        }
    }
}
