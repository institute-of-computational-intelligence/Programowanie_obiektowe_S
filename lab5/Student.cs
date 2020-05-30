using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Student : Person
    {
        public string Subject { get; set; }
        public string Specjality { get; set; }
        public int Year { get; set; }
        public int Group { get; set; }
        public int IndexId { get; set; }
        public List<FinalGrade> Grades { get; set; }
        public Student():base()
        { 
        }
        public Student(string name,string surname,DateTime dateofbirth,string subject,string specjal,int year,int group,int index) : base(name, surname, dateofbirth)
        {
            this.Subject = subject;
            this.Specjality = specjal;
            this.Year = year;
            this.Group = group;
            this.IndexId = index;

            Grades = new List<FinalGrade>();
        }

        public override string ToString()
        {
            return base.ToString() + $"Subject:{Subject} Specjality: {Specjality} Year: {Year} group: {Group} index: {IndexId}";
        }

        public override void details()
        {
            Console.WriteLine(this);
        }

        public void PrintGrades()
        {
            foreach (FinalGrade gr in Grades)
                Console.WriteLine(gr);            
        }

        public void AddGrade(Course name,double grade,DateTime date)
        {
            bool hasGrade = false;
            foreach(FinalGrade gr in Grades)
                if (gr.Coure.Equals(name))
                {
                    hasGrade = true;
                    break;
                }
            if (!hasGrade)
                Grades.Add(new FinalGrade(grade, date, name));
        }
    }

}
