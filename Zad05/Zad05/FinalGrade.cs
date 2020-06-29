using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad05 {
    public class FinalGrade: IInfo {
        public Subject Subject { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }

        public FinalGrade(Subject subject, double value, DateTime date) {
            Subject = subject;
            Value = value;
            Date = date;
        }
        public override string ToString() {
            return $"Grade: {Value}, Subject: {Subject}, Date: {Date}";
        }
        public virtual void DisplayInfo() {
            Console.WriteLine(this);
        }
    }
}
