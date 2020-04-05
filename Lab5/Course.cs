using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Course:IInfo
    {
        private string name, subject, speciality;
        private int semester, hours;
        private List<SummaryGrade> grades = new List<SummaryGrade>();

        public Course()
        {
        }

        public Course(string name, string subject, string speciality, int semester, int hours)
        {
            this.name = name;
            this.subject = subject;
            this.speciality = speciality;
            this.semester = semester;
            this.hours = hours;
        }

        public string Name { get => name; set => name = value; }
        public string Subject { get => subject; set => subject = value; }
        public string Speciality { get => speciality; set => speciality = value; }
        public int Semester { get => semester; set => semester = value; }
        public int Hours { get => hours; set => hours = value; }

        public void AddGrade(SummaryGrade grade)
        {
            grades.Add(grade);
        }

        public void Details()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return $"Pzedmiot: {name} {subject} {speciality} {semester} {hours}";
        }
    }
}
