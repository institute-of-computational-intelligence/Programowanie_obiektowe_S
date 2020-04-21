using System;
using System.Collections.Generic;
using System.Linq;
using Generic.Extensions;

namespace Lab5.BLL
{
    public class Department : IAction, IInfo
    {
        public string Name { get; set; }
        public Person Dean { get; set; }
        public IList<OrganizationUnit> OrganizationUnits { get; set; }
        public IList<Subject> Subjects { get; set; }
        public IList<Student> Students { get; set; }
        public Department(string name, Person dean, List<OrganizationUnit> units = null, IList<Subject> subjects = null, IList<Student> students = null)
        {
            Name = name;
            Dean = dean;
            OrganizationUnits = units ?? new List<OrganizationUnit>();
            Subjects = subjects ?? new List<Subject>();
            Students = students ?? new List<Student>();
        }

        public override string ToString()
        {
            return $"Department: {Name}, Dean: {Dean}";
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"{this}");

            Console.WriteLine($"\n\tUnits:");
            OrganizationUnits.ForEach(s =>  Console.WriteLine($"\t{s}"));

            Console.WriteLine($"\n\tSubjects:");
            Subjects.ForEach(s => Console.WriteLine($"\t{s}"));

            Console.WriteLine($"\n\tStudents:");
            Students.ForEach(s =>  Console.WriteLine($"\t{s}"));
        }


    }
}
