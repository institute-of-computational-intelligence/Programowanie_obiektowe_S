using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab8.Model.Attributes;

namespace Lab8.Model
{
    [DbTab]
    public class Grade
    {
        [DbCol]
        public int Id { get; set; }
        [DbCol]
        public DateTime Date  { get; set; }
        [DbCol]
        public string  Subject { get; set; }
        [DbCol]
        public float Value { get; set; }
        [DbCol]
        public int StudentNo { get; set; }

        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
