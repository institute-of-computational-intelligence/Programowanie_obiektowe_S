using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Subject> przedmioty = new List<Subject>();
            przedmioty.Add(new Subject("A1", "A1", "A", 1, 21));
            przedmioty.Add(new Subject("B", "A1", "A", 1, 21));
            przedmioty.Add(new Subject("C", "A1", "A", 2, 21));
            przedmioty.Add(new Subject("D", "B1", "A", 2, 21));
            przedmioty.Add(new Subject("E", "B1", "A", 3, 21));
            przedmioty.Add(new Subject("F", "B1", "A", 3, 21));
            przedmioty.Add(new Subject("G", "C1", "B", 4, 21));
            przedmioty.Add(new Subject("H", "C1", "B", 4, 21));

            List<Student> studenci = new List<Student>();
            studenci.Add(new Student("Adsdw", "Efewf", "15-1-56", "A1", "a1", 1, 1, 123456));
            studenci.Add(new Student("Adwad", "Efeawv", "15-1-56", "B1", "b1", 2, 1, 123457));
            studenci.Add(new Student("Avdve", "Efvevew", "15-1-56", "A1", "b1", 3, 1, 123458));
            studenci.Add(new Student("Aefwg", "Efewffw", "15-1-56", "B1", "b1", 2, 1, 123459));
            studenci.Add(new Student("Adbrrb", "Efewfqw", "15-1-56", "B1", "a1", 1, 2, 123460));
            studenci.Add(new Student("Adsrbeww", "Efevee", "15-1-56", "V1", "a1", 2, 2, 123461));
            studenci.Add(new Student("Adfeww", "Efewf", "15-1-56", "A1", "a1", 2, 2, 123462));
            studenci.Add(new Student("Adveve", "Efvevr", "15-1-56", "A1", "c1", 3, 1, 123463));
            studenci.Add(new Student("Add", "Efebrr", "15-1-56", "B1", "c1", 4, 1, 123464));
            studenci.Add(new Student("Advev", "Efq3e", "15-1-56", "A1", "v1", 1, 3, 123465));
            studenci.Add(new Student("Adsefe", "Efbtt", "15-1-56", "C1", "a1", 3, 3, 123466));
            studenci.Add(new Student("Adsdw", "Ef3ees", "15-1-56", "C1", "c1", 1, 3, 123467));
            studenci.Add(new Student("Adsdw", "Efmiok", "15-1-56", "A1", "a1", 4, 3, 123468));

            List<Lecturer> wykladowcy = new List<Lecturer>();
            wykladowcy.Add(new Lecturer("Azscsz", "Vbdbege", "54-45-61", "M1", "Ad1"));
            wykladowcy.Add(new Lecturer("Zdwdwf", "Vbddwad", "54-45-61", "M1", "Ad2"));
            wykladowcy.Add(new Lecturer("Afwaw", "Brgrgr", "54-45-61", "M2", "Ad1"));
            wykladowcy.Add(new Lecturer("Ajyky", "Nrgr", "54-45-61", "M2", "Ad3"));
            wykladowcy.Add(new Lecturer("Azegegey", "Yrtyrt", "54-45-61", "M3", "Ad2"));

            Department wimii = new Department();
            wimii.AddUnit("Lorem", "ul. Ipsum");
            wimii.AddUnit("Nulla", "ul. Lobortis");
            foreach(var x in przedmioty)
            {
                wimii.AddSubject(x);
            }
            foreach(var x in studenci)
            {
                wimii.AddStudent(x);
            }
            wimii.AddLecturer(wykladowcy[0], "Lorem");
            wimii.AddLecturer(wykladowcy[1], "Lorem");
            wimii.AddLecturer(wykladowcy[2], "Nulla");
            wimii.AddLecturer(wykladowcy[3], "Lorem");
            wimii.AddLecturer(wykladowcy[4], "Nulla");

            wimii.InfoStudents(true);
            Console.WriteLine("_______________________________________________________________________________");
            wimii.InfoSubjects();
            Console.WriteLine("_______________________________________________________________________________");
            wimii.InfoUnits(true);
            Console.WriteLine("_______________________________________________________________________________\n\n\n");

            wimii.MoveLecturer(wykladowcy[2], "Nulla", "Lorem");
            wimii.AddGrade(123456, przedmioty[0], 5.0, "999-999-999");
            wimii.RemoveStudent(123459);
            wimii.InfoStudents(true);
            Console.WriteLine("_______________________________________________________________________________");
            wimii.InfoSubjects();
            Console.WriteLine("_______________________________________________________________________________");
            wimii.InfoUnits(true);

            Console.ReadKey();
        }
    }
}