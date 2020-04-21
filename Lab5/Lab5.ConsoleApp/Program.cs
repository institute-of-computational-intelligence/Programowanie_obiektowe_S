using System;
using System.Collections.Generic;
using System.Linq;
using Generic.Extensions;
using Lab5.BLL;

namespace Lab5.ConsoleApp
{
    public class Program
    {
        private static void Main()
        {
            Department db = new Department("WIM",
                new Lecturer("Jan", "Nowak", DateTime.Now.AddYears(-56), "dr hab.", "dziekan"),
                new List<OrganizationUnit>
                {
                    new OrganizationUnit("IOO", "Rolnicza 2"),
                    new OrganizationUnit("SKL", "Miedziana 13")
                }
            );

           db.Add(new Student("Jacek", "Placek", new DateTime(1989, 2, 12), "Matematyka", 1))
                .Add(new Student("Marek", "Kulawy", new DateTime(2001, 12, 1), "Matematyka", 1))
                .PrintInfo()
                .Get<Student>(x=>x.Group == 1).PrintInfo();

            db.Get<Student>().GetList<FinalGrade>(g => g.Subject.Name == "Informatyka").PrintInfo();

            db.Add(new Subject("PO", "Informatyka", 2, 10))
                .Add(new Subject("Sieci", "Informatyka", 2, 30));

           var s= db.Get<OrganizationUnit>(x => x.Name == "SKL");

            db.Get<OrganizationUnit>( x=>x.Name == "SKL")
                .Add(new Lecturer("Maria", "Mangdalena", new DateTime(1912, 12, 1), "mgr", "Katecheta"));

            db.Get<OrganizationUnit>().PrintInfo();

            db.Get<OrganizationUnit>(x=>x.Name=="SKL")
                .Remove<Lecturer>(l => l.FirstName == "Maria")
                .AddInto(db.Get<OrganizationUnit>(x => x.Name == "IOO"));

            db.GetList<OrganizationUnit>().PrintInfo();
            Console.ReadKey();
        }
    }
}
