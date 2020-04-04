using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Student : Person 
    {
        public string Specialization { get; set; }
        public int Year { get; set; }
        public int Group { get; set; }
        public int IndexId { get; set; }

        public IList<FinalGrade> Grades;

        public Student() :
            base()
        {
            Specialization = "";
            Year = 0;
            Group = 0;
            IndexId = 0;
            Grades = new List<FinalGrade>();
        }
        public Student(string fName, string lName, DateTime bDate, string specialization, int year, int group, int indexId) :
            base(fName, lName, bDate)
        {
            Specialization = specialization;
            Year = year;
            Group = group;
            IndexId = indexId;
            Grades = new List<FinalGrade>();
        }

        public void AddGrade(FinalGrade grade)
        {
            Grades.Add(grade);
        }
        public void AddGrade(Subject subject, double value, DateTime date)
        {
            FinalGrade gr = new FinalGrade(subject, value, date);
            Grades.Add(gr);
        }
        public void DeleteGrade(FinalGrade grade)
        {
            foreach (var g in Grades)
            {
                if (g.Subject == grade.Subject && g.Date == grade.Date && g.Value == grade.Value)
                    Grades.Remove(g);
            }
        }
        public void DeleteGrades()
        {
            Grades.Clear();
        }
        public override string ToString()
        {
            return base.ToString() + $"\nSpecjalizacja: {Specialization}, Rok: {Year}, grupa: {Group}, nr indeksu: {IndexId}";
        }
        public string ToString(bool gradesInfo)
        {
            if (gradesInfo == false)
                return base.ToString() + $"\nSpecjalizacja: {Specialization}, Rok: {Year}, grupa: {Group}, nr indeksu: {IndexId}";
            else
            {
                string str = base.ToString() + $"\nSpecjalizacja: {Specialization}, Rok: {Year}, grupa: {Group}, nr indeksu: {IndexId}"; ;
                foreach (var g in Grades)
                {
                    str += g.ToString() + "\n";
                }
                return str;
            }

        }
        public override void DisplayInfo()
        {
            Console.WriteLine(this);
        }

        
    }
}
