using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Student :Person
    {
        public int Group { get; set; }
        public int IndexId { get; set; }
        public string Specialization { get; set; }
        public int Year { get; set; }

        public IList<FinalGrade> Grades;

        public Student(string firstName, string lastName, DateTime dateOfBirth, int group, int indexId, string specialization, int year) 
                    :base(firstName, lastName, dateOfBirth)
        {
            Group = group;
            IndexId = indexId;
            Specialization = specialization;
            Year = year;
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

        }

        public string ToString()
        {

        }

        public string ToString(bool gradesInfo)
        {

        }

    }
}
