using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public class Note
    {
        private double grade;
        private string date;
        private string subject;

        public double Grade { get => grade; set => grade = value; }
        public string Date { get => date; set => date = value; }
        public string Subject { get => subject; set => subject = value; }

        public Note() { }

        public Note(double grade_, string date_, string subject_)
        {
            grade = grade_;
            date = date_;
            subject = subject_;
        }

        public override string ToString()
        {
            return $"Ocena: {grade}, Data: {date}, Przedmiot: {subject}";
        }

    }
}
