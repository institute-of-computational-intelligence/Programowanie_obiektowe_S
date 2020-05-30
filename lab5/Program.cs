using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Department wimii = new Department("Wydzial Inzynierii mechanicznej i ninformatyki");


            Student s1 = new Student("Damian", "Nowak", new DateTime(1986,12,5), "Informatyka", "Sieci komputerowe", 3, 2, 154259);
            Student s2 = new Student("Mateusz", "Zima", new DateTime(1998, 1, 22), "Informatyka", "Programowanie aplikacji", 3, 4, 153327);
            Student s3 = new Student("Dominik", "Myto", new DateTime(1999, 12, 2), "Elektronika", "Robotyka", 3, 3, 159941);
            Student s4 = new Student("Katarzyna", "Kowalska", new DateTime(1995, 4, 26), "Informatyka", "Sieci komputerowe", 4, 1, 174984);
            Student s5 = new Student("Adam", "Zygała", new DateTime(1998, 04, 25), "Elektronika", "Robotyka", 3, 2, 127478);
            Student s6 = new Student("Daniel", "Nowicki", new DateTime(1998, 7, 30), "Informatyka", "Sieci komputerowe", 3, 1, 156879);

            wimii.AddStudent(s1);
            wimii.AddStudent(s2);
            wimii.AddStudent(s3);
            wimii.AddStudent(s4);
            wimii.AddStudent(s5);
            wimii.AddStudent(s6);

            Lectuer l1 = new Lectuer("Richard", "Stallman", new DateTime(1986, 12, 5), "prof. dr hab. inż.", "wozny");
            Lectuer l2 = new Lectuer("Linus", "Torvalds", new DateTime(1995, 4, 26), "prof. inż.", "adiutant");
            Lectuer l3 = new Lectuer("James", "Gosling", new DateTime(1998, 7, 30), "prof. dr", "sprzatacz");

            wimii.AddUnit("Katedra Inżynierii Oprogramowania", "Wąska 24/33");
            wimii.AddUnit("Katedra Zaawansowanych Technologii", "Wyboista 102");

            wimii.AddLectuler(l1, "Katedra Inżynierii Oprogramowania");
            wimii.AddLectuler(l2, "Katedra Zaawansowanych Technologii");
            wimii.AddLectuler(l3, "Katedra Zaawansowanych Technologii");

            Course p1 = new Course("Programowanie obiektowe", "Informatyka", "Programowanie aplikacji", 4, 30);
            Course p2 = new Course("Analiza matematyczna", "Mechatronika", "Budowa maszyn", 2, 30);
            Course p3 = new Course("Programowanie niskopoziomowe", "Informatyka", "Programowanie aplikacji", 4, 30);
            Course p4 = new Course("Bazy danych", "Informatyka", "Sieci komputerowe", 4, 30);
            Course p5 = new Course("Elektronika i elektrotechnika", "Elektronika", "Robotyka", 4, 15);
            Course p6 = new Course("Budowa układów scalonych", "Mechatronika", "Budowa maszyn", 2, 30);

            wimii.AddCourse(p1);
            wimii.AddCourse(p2);
            wimii.AddCourse(p3);
            wimii.AddCourse(p4);
            wimii.AddCourse(p5);
            wimii.AddCourse(p6);

            s1.AddGrade(p1, 4.5, new DateTime(1998, 7, 30));
            s1.AddGrade(p3, 4.0, new DateTime(1208, 7, 30));
            wimii.AddGrade(154259, p5, 5, new DateTime(2020, 7, 30));
            wimii.AddGrade(154259, p6, 4, new DateTime(1899, 7, 30));

            s2.AddGrade(p1, 4.0, new DateTime(1208, 7, 30));
            s2.AddGrade(p3, 4.0, new DateTime(1208, 7, 30));
            wimii.AddGrade(153327, p5, 3, new DateTime(1208, 7, 30));
            wimii.AddGrade(153327, p6, 3, new DateTime(1208, 7, 30));

            wimii.AddGrade(159941, p5, 3, new DateTime(1410, 7, 30));
            wimii.AddGrade(159941, p6, 4, new DateTime(150, 7, 30));

            wimii.InfoUnit(true);
            wimii.InfoCours();
            wimii.InfoStudent(true);

            wimii.RemoveStudent(127478);
            wimii.RemoveStudent(153327);
            wimii.RemoveStudent(154259);

            wimii.InfoStudent(false);

            s2.details();
            s2.PrintGrades();

            wimii.Transfer(l1, "Katedra Inżynierii Oprogramowania", "Katedra Zaawansowanych Technologii");

            wimii.InfoUnit(true);

            Console.ReadKey();
        }
    }
}
