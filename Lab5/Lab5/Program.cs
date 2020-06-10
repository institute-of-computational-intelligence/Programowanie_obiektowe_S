using System;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Lecturer l2 = new Lecturer("Jan", "Kowalski", "12-12-1982", "dr. inż.", "Ćwiczeniowiec");
            Student s2 = new Student("Marek", "Mostowiak", "13-05-2000", "Matematyka", "Matematyka Stosowana", 2, 3, 129230);
            Course c2 = new Course("Język Angielski", "Matematyka", "Matematyka Stosowana", 4, 30);
            //FinalGrade g2 = new FinalGrade(3.0, "19.04.2020", c2);
            Unit u1 = new Unit("Jednostka", "Dąbrowskiego 13");

            Faculty f1 = new Faculty();
            f1.AddCourse(c2);
            f1.AddUnit("Jednostkowa","Księżycowa 12");
            f1.AddStudent(s2);
            f1.AddLecturer(l2, "Jednostkowa");
            f1.AddGrade(129230, "Język Angielski", 4.5, "19.04.2020");

            f1.Details();

            f1.AddUnit("A", "B");
            f1.RemoveStudent(129230);
            f1.MoveLecturer(l2, "Jednostkowa", "A");

            f1.Details();

            Console.ReadKey();
        }
    }
}
