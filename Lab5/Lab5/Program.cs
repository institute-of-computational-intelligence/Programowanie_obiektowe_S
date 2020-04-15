using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
     public class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student("Jan", "Kowalski", new DateTime(1995, 1, 1), "Informatyka", 1, 1, 123123);
            Student student2 = new Student("Piotr", "Nowak", new DateTime(1990, 1, 1), "Matematyka", 3, 2, 321312);
            Person student3 = new Student("Adam", "Bedrnarski", new DateTime(1993, 1, 1), "Informatyka", 1, 2, 765123);

            Subject subject1 = new Subject("Programowanie obiektowe", "Informatyka", 4, 30);
            Subject subject2 = new Subject("Bazy danych", "Informatyka", 4, 30);
            Subject subject3 = new Subject("Algebra", "Matematyka", 1, 15);
            Subject subject4 = new Subject("Analiza", "Matematyka", 1, 30);

            FinalGrade grade1 = new FinalGrade(subject1, 4.5d, DateTime.Now.AddDays(30));
            FinalGrade grade2 = new FinalGrade(subject1, 5.0d, DateTime.Now.AddDays(10));
            FinalGrade grade3 = new FinalGrade(subject2, 3.5d, DateTime.Now.AddDays(50));
            FinalGrade grade4 = new FinalGrade(subject2, 3.0d, DateTime.Now.AddDays(20));
            FinalGrade grade5 = new FinalGrade(subject3, 5.0d, DateTime.Now.AddDays(10));
            FinalGrade grade6 = new FinalGrade(subject3, 4.0d, DateTime.Now.AddDays(10));
            FinalGrade grade7 = new FinalGrade(subject4, 4.0d, DateTime.Now.AddDays(30));
            FinalGrade grade8 = new FinalGrade(subject4, 3.5d, DateTime.Now.AddDays(20));

            student1.AddGrade(grade1);
            student1.AddGrade(grade3);
            student2.AddGrade(grade2);
            student2.AddGrade(grade4);

            ((Student)student3).AddGrade(grade5);
            ((Student)student3).AddGrade(grade6);
            ((Student)student3).AddGrade(grade7);
            ((Student)student3).AddGrade(grade8);

            Lecturer lecturer1 = new Lecturer("Krzysztof", "Nowakowski", new DateTime(1978, 12, 12), "dr inż.", "Adiunkt");
            Lecturer lecturer2 = new Lecturer("Jan", "Kowalski", new DateTime(1960, 10, 12), "Prof. dr hab. inż.", "Profesor");
            Lecturer lecturer3 = new Lecturer("Adam", "Nowakowski", new DateTime(1968, 2, 12), "dr inż.", "Adiunkt");
            Lecturer lecturer4 = new Lecturer("Arkadiusz", "Bednarski", new DateTime(1969, 1, 12), "dr hab. inż.", "Profesor");
            OrganizationUnit organizationUnit1 = new OrganizationUnit("Instytut Informatyki Teoretycznej i Stosowanej", "Częstochowa", new List<Lecturer>());

            OrganizationUnit organizationUnit2 = new OrganizationUnit("Instytut Inteligentnych Systemów Informatycznych", "Częstochowa", new List<Lecturer>());

            organizationUnit1.AddLecturer(lecturer1);
            organizationUnit1.AddLecturer(lecturer2);
            organizationUnit2.AddLecturer(lecturer3);
            organizationUnit2.AddLecturer(lecturer4);

            Lecturer dean = new Lecturer("Tadeusz", "Nowak", new DateTime(1955, 1, 12), "Prof. dr hab.inż.", "Profesor");

            Department department = new Department("Wydział Inżynierii Mechanicznej i Informatyki", dean, new List<Subject>(), new Dictionary<int, Student>());

            department.AddUnit(organizationUnit1);
            department.AddUnit(organizationUnit2);

            department.AddLecturer(dean, organizationUnit2);

            department.AddSubject(subject1);
            department.AddSubject(subject2);
            department.AddSubject(subject3);
            department.AddSubject(subject4);

            department.AddStudent(student1);
            department.AddStudent(student2);
            department.AddStudent((Student)student3);

            department.AddGrade(765123, "Programowanie obiektowe", 3.0d, DateTime.Now);

            department.DeleteStudent(123123);

            department.RelocateLecturer(lecturer2, organizationUnit1, organizationUnit2);

            department.StudentsInfo(true);
            department.SubjectsInfo();
            department.UnitsInfo(true);

            Console.WriteLine();
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine(department);
            Console.ReadKey();
        }
    }
}
