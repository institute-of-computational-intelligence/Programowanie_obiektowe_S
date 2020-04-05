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
            Department mit = new Department("Massechusets Information Technology Department");

            mit.AddUnit("CIA", "Stanta Cruz 342, Messachussetsss");
            mit.AddUnit("FBI", "Washington 342, Messachussetsss");

            Lector l1 = new Lector("Richard", "Stallman", "1960.04.02", "prof. dr hab. inż.");
            Lector l2 = new Lector("Linus", "Torvalds", "1990.04.12", "prof. inż.");
            Lector l3 = new Lector("James", "Gosling", "1963.01.02", "prof. dr");

            if (!mit.AddLector(l1, "Error"))
                Console.WriteLine("Blad dodania wykladowcy");

            mit.AddLector(l1, "CIA");
            mit.AddLector(l2, "FBI");
            mit.AddLector(l3, "FBI");

            mit.UnitDetails(true);
            
            Console.ReadKey();
            Console.Clear();

            Course c1 = new Course("Programming", "IT", "Spec", 2, 15);
            Course c2 = new Course("Art", "TIT", "Autistic", 1, 35);

            mit.AddCourse(c1);
            mit.AddCourse(c2);

            Student s1 = new Student("Mark", "Zuckerberg", "2004.04.19", "IT", "Spec", 2, 3, 123312);
            Student s2 = new Student("Steve", "Jobs", "2001.12.19", "TIT", "Autistic", 1, 2, 123314);

            mit.AddStudent(s1);
            mit.AddStudent(s2);

            s1.AddGrade("Massechusets Information Technology Department", "Programming", 5.0, "2020.03.13");
            s1.AddGrade("Massechusets Information Technology Department", "Art", 3.5, "2020.04.13");

            mit.AddGrade(123312, "Programming", 4.5, "2010.03.03");
            mit.AddGrade(123314, "Art", 4.0, "2010.03.03");

            mit.CoursesDetails();
            Console.WriteLine("--------------");
            mit.StudentsDetails(true);

            Console.ReadKey();
        }
    }
}
