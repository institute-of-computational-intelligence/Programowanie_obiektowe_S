using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class Program
    {
        static void Main(string[] args)
        {
            Faculty wimii = new Faculty("Wydzial Inzynierii Mechanicznej i Informatyki");

            Subject[] subjects = new Subject[] {
                new Subject("Programowanie niskopoziomowe lab.", "Informatyka", "Inzynieria Oprogramowania", 4, 30),
                new Subject("Programowanie niskopoziomowe wyk.", "Informatyka", "Inzynieria Oprogramowania", 4, 30),
                new Subject("Programowanie obiektowe lab.", "Informatyka", "Inzynieria Oprogramowania", 4, 30),
                new Subject("Programowanie obiektowe wyk.", "Informatyka", "Inzynieria Oprogramowania", 4, 45),
                new Subject("Systemy Operacyjne lab.", "Informatyka", "Inzynieria Oprogramowania", 4, 20),
                new Subject("Systemy Operacyjne wyk.", "Informatyka", "Inzynieria Oprogramowania", 4, 15),
                new Subject("Analiza wyk.", "Mechatronika", "Mechatronika", 1, 15),
                new Subject("Analiza lab.", "Mechatronika", "Mechatronika", 1, 30),
            };

            wimii.AddStudent(new Student("Jan", "Kowalski", new DateTime(1986, 12, 5), "Informatyka", "Inzyniera Oprogramowanie", 3, 2, 123456));
            wimii.AddStudent(new Student("Jan", "Nowak", new DateTime(1992, 12, 5), "Informatyka", "Inzyniera Oprogramowanie", 2, 5, 115542));

            wimii.PrintStudents(false);

            wimii.RemoveStudent(123456);

            wimii.PrintStudents(false);

            wimii.AddStudent(new Student("Andrzej", "Nowakowski", new DateTime(1992, 12, 5), "Informatyka", "Inzyniera Oprogramowanie", 2, 5, 115542));
            wimii.AddSubject(subjects[5]);
            wimii.AddGrade(115542, "Systemy Operacyjne wyk.", 5, new DateTime(2019, 12, 5));
            wimii.PrintStudents(true);

            wimii.AddGrade(123456, "Systemy Operacyjne wyk.", 5, new DateTime(2019, 12, 5));
            wimii.PrintStudents(true);

            wimii.AddUnit("Katedra Inteligentnych Systemów Informatycznych", "Al.Armii Krajowej 36 42 - 200 Częstochowa");
            wimii.AddLecturer(new Lecturer("Jan", "Kowal", new DateTime(1977, 5, 4), "Dr inż.", "Wykladowca"), "Katedra Inteligentnych Systemów Informatycznych");

            wimii.PrintUnits(true);

            Console.ReadKey();
        }
    }
}
