using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Student : Person
    {
        public int Group { get; set; }
        public int IndexId { get; set; }
        public string Specialization { get; set; }
        public int Year { get; set; }

        public List<FinalGrade> Grades;

        public Student(string firstName, string lastName, DateTime dateOfBirth, string specialization, int group, int indexId, int year)
                    : base(firstName, lastName, dateOfBirth)
        {
            Group = group;
            IndexId = indexId;
            Specialization = specialization;
            Year = year;
            Grades = new List<FinalGrade>();
        }

        public void AddGrade(FinalGrade grade)
        {
            Grades.Add(grade);
        }

        public void AddGrade(Subject subjet, double value, DateTime date)
        {
            Grades.Add(new FinalGrade(subjet, value, date));
        }

        public void DeleteGrade(FinalGrade grade)
        {
            Grades.Remove(grade);
        }

        public void DeleteGrades()
        {
            Grades.Clear();
        }

        public void DisplayGrades()
        {
            foreach (FinalGrade grade in Grades)
            {
                grade.DisplayInfo();
            }
        }

        //public override string ToString() nie ppotrzebne bo ten niżzej robi to samo plus wiecej
       // {
      //      return base.ToString() + $"\nSpec: {Specialization}, Year: {Year}, group: {Group}, no index: {IndexId}";
      //  }

        public string ToString(bool gradesInfo = false)
        {
            string str = base.ToString() + $"\nSpec: {Specialization}, Year: {Year}, group: {Group}, no index: {IndexId}";
            if(gradesInfo == true)
            {
                foreach (FinalGrade grade in Grades)
                {
                    str += grade.ToString();
                }
            }
            return str;
        }
    }
}
