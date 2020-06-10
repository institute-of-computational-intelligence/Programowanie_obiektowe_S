using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    class Student : Person
    {
        private string subject;
        private string specialisation;
        private int year;
        private int group;
        private int indexNumber;
        private List<FinalGrade> grades = new List<FinalGrade>();

        public int IndexNumber { get => indexNumber; set => indexNumber = value; }

        public Student()
        {
            subject = "--";
            specialisation = "--";
            year = 0;
            group = 0;
            indexNumber = 0;
        }

        public Student(string name_, string surname_, string dateOB, string subject_, string spec_, int year_, int group_, int indexNum_) :
            base(name_, surname_, dateOB)
        {
            subject = subject_;
            specialisation = spec_;
            year = year_;
            group = group_;
            indexNumber = indexNum_;
        }

        public void AddGrade(FinalGrade grade)
        {
            grades.Add(grade);
        }

        public override string ToString()
        {
            return base.ToString() + $"\r\nStudent Data| Subject: {subject}, [{specialisation}]\r\n\tYear: {year}, group: {group}, index number: {indexNumber}";
        }

        public override void Details()
        {
            Console.WriteLine(this);
            foreach(FinalGrade g in grades)
                g.Details();
            Console.WriteLine("\r\n");
        }
    }
}
