using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Student:Person, IInfo
    {
        private string subject;
        private string specialisation;
        private int year;
        private int group;
        private int index;
        private List<SummaryGrade> grades = new List<SummaryGrade>();
        private List<Department> departments = new List<Department>();

        public Student():base()
        {
        }

        public Student(string name, string surname, string born, string subject, string specialisation, int year, int group, int index, Department department):base(name, surname,born)
        {
            department.AddStudent(this);
            this.subject = subject;
            this.specialisation = specialisation;
            this.year = year;
            this.group = group;
            this.index = index;
            this.departments.Add(department);
        }
        public Student(string name, string surname, string born, string subject, string specialisation, int year, int group, int index) : base(name, surname, born)
        {
            this.subject = subject;
            this.specialisation = specialisation;
            this.year = year;
            this.group = group;
            this.index = index;
        }

        public string Subject { get => subject; set => subject = value; }
        public string Specialisation { get => specialisation; set => specialisation = value; }
        public int Year { get => year; set => year = value; }
        public int Group { get => group; set => group = value; }
        public int Index { get => index; set => index = value; }

        public bool AddGrade(string departmentName, string courseName, double grade, string date)
        {
            Department res = null;
            foreach (Department d in departments)
                if (d.Name == departmentName)
                    res = d;
            if (res != null)
            {
                if (res.AddGrade(index, courseName, grade, date))
                    return true;
                else
                    return false;
            }
            return false;
        }

        public void AddGrade(SummaryGrade Grade)
        {
            grades.Add(Grade);
        }

        public override void Details()
        {
            Console.WriteLine(this);
        }

        public void GradesDetails()
        {
            Console.WriteLine(String.Join("\r\n", grades));
        }

        public override string ToString()
        {
            return base.ToString() + $" {index} grupa:{group} rok:{year} {subject} {specialisation}";
        }
    }
}
