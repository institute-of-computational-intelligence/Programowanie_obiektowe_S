using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Student:Person
    {
        public int Group { get; set; }
        public int IndexID { get; set; }
        public int Year { get; set; }
        public string Specialization { get; set; }
        public IList<FinalGrade> Grades;

        public Student():base()
        {
            Group = 0;
            IndexID = 0;
            Year = 0;
            Specialization = "Unknwon";
            Grades = new List<FinalGrade>();
        }

        public Student(string firstName, string lastName, DateTime dateOfBirth,
            string specialization, int year, int group, int indexID)
            :base(firstName,lastName,dateOfBirth)
        {
            Group = group;
            IndexID = indexID;
            Year = year;
            Specialization = specialization;
            Grades = new List<FinalGrade>();
        }

        public void AddGrade(FinalGrade grade)
        {
            Grades.Add(grade);
        }

        public void AddGrade(Subject subject, double value, DateTime date)
        {
            Grades.Add(new FinalGrade(subject, value, date));
        }

        public void DeleteGrade(FinalGrade grade)
        {
            bool check = false;
            foreach (var item in Grades)
            {
                if (item.Equals(grade))
                {
                    Grades.Remove(grade);
                    check = true;
                }
            }
            if (check)
            {
                Console.WriteLine("Podana ocena została usunieta\n");
            }
            else
            {
                Console.WriteLine("Brak podanej oceny\n");
            }
        }

        public void DeleteGrades()
        {
            Grades.Clear();
        }

        public void DisplayGrades()
        {
            Console.WriteLine("Grades:");
            foreach (var item in Grades)
            {
                item.DisplayInfo();
            }
        }

        public override string ToString()
        {
            return base.ToString() +
                $"\nSpecialization:{Specialization}, Index:{IndexID}, Group:{Group}, Year:{Year}";
        }

        public string ToString(bool gradesInfo)
        {
            if (gradesInfo == false)
            {
                return base.ToString() +
                $"\nSpecialization:{Specialization}, Index:{IndexID}, Group:{Group}, Year:{Year}\n";
            }
            else
            {
                string str = base.ToString() +
                $"\nSpecialization:{Specialization}, Index:{IndexID}, Group:{Group}, Year:{Year}\n";
                DisplayGrades();
                return str;
            }
        }

        public override void DisplayInfo()
        {
            Console.WriteLine(this);
        }
    }
}
