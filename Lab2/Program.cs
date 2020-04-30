using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Person o = new Person("Adam", "Mis", "20.03.1980");
            Person o2 = new Student("Michal", "Kot", "13.04.1990", 2, 1, 12345);
            Person o3 = new Footballer("Mateusz", "Zbik", "10.08.1986", "obronca", "FC Czestochowa");

            o.WriteInfo();
            o2.WriteInfo();
            o3.WriteInfo();

            Student s = new Student("Krzysztof", "Jez", "22.12.1990", 2, 5, 54321);
            Footballer p = new Footballer("Piotr", "Kos", "14.09.1984", "napastnik", "FC Politechnika");

            s.WriteInfo();
            p.WriteInfo();

            ((Footballer)o3).ScoreGoal();
            p.ScoreGoal();
            p.ScoreGoal();

            o3.WriteInfo();
            p.WriteInfo();

            Console.ReadKey();
        }
    }
}
