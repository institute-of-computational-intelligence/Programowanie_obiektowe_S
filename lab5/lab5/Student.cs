using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Student : Person
    {
        public int Group { get; set; }
        public int IndexId { get; set; }
        public string Specjalization { get; set; }
        public int Year { get; set; }
        public IList<FinalGrade> finalGrades { get; set; }


        public void AddGrade (FinalGrade grade)
        {
            finalGrades.Add(grade);
        }
        public void AddGrade (Subject subject, double value, DateTime time)
        {
            finalGrades.Add(new FinalGrade(subject, value, time));
        }
        public void DeleteGrade (FinalGrade grade)
        {
            finalGrades.Remove(grade);
        }
        public void DeleteGrades()
        {
            finalGrades.Clear();
        }
        
        public Student() : base()
        {
            Specjalization = "";
            Year = 0;
            Group = 0;
            IndexId = 0;
            finalGrades = new List<FinalGrade>();
        }
        public Student (string firstName, string lastName, DateTime dateOfBith, string specjalization, int year, int group, int indexid) : base (firstName, lastName, dateOfBith)
        {
            Specjalization = specjalization;
            Year = year;
            Group = group;
            IndexId = indexid;
            finalGrades = new List<FinalGrade>();
        }
        public override string ToString()
        {
            return base.ToString() + $"\nSpecjalizacja: {Specjalization}, Rok: {Year}, grupa: {Group}, nr indeksu: {IndexId}";
        }
        public string ToString(bool gradesInfo)
        {
            if (gradesInfo == false)
                return base.ToString() + $"\nSpecjalizacja: {Specjalization}, Rok: {Year}, grupa: {Group}, nr indeksu: {IndexId}";
            else
            {
                string str = base.ToString() + $"\nSpecjalizacja: {Specjalization}, Rok: {Year}, grupa: {Group}, nr indeksu: {IndexId}"; ;
                foreach (var g in finalGrades)
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
