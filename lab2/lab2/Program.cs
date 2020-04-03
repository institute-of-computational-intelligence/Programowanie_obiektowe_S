using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Adam", "Miś", new DateTime(1990, 3, 20));
            Person person2 = new Student("Michał", "Kot", new DateTime(1990, 4, 13), 2, 1, 12345);
            Person person3 = new Player("Mateusz", "Żbik", new DateTime(1986, 8, 10), "striker", "FC Barcelona");
            person1.Details();
            person2.Details();
            person3.Details();
            Student student = new Student("Krzysztof", "Jeż", new DateTime(1990, 12, 29), 2, 5, 54321);
            Player footballer = new FootballPlayer("Piotr", "Kos", new DateTime(1984, 9, 14), "striker", "FC Politechnika");
            student.Details();
            footballer.Details();
            ((Player)person3).ScoreGoal();
            footballer.ScoreGoal();
            footballer.ScoreGoal();
            person3.Details();
            footballer.Details();
            Console.WriteLine("--------------------------");
            Console.WriteLine();

            ((Student)person2).AddGrade("PO", new DateTime(2011, 2, 20), 5.0);
            ((Student)person2).AddGrade("Bazy Danych", new DateTime(2011, 2, 13), 5.0);

            person2.Details();

            Grade grade = new Grade("Bazy Danych", new DateTime(2011, 5, 1), 5.0);
            student.AddGrade("AWWW", new DateTime(2011, 5, 11), 5.0);
            student.AddGrade("AWWW", new DateTime(2011, 4, 2), 4.5);

            student.Details();

            student.RemoveGrade("AWWW", new DateTime(2011, 4, 2), 4.5);

            student.Details();

            student.AddGrade("AWWW", new DateTime(2011, 4, 2), 4.5);
            student.RemoveGrade("AWWW");


            student.Details();

            student.AddGrade("AWWW", new DateTime(2011, 4, 3), 5.0);
            student.RemoveGrades();

            student.Details();

            Console.ReadKey();
        }
    }
}