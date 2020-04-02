using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lab4.Interfaces;

namespace Lab4.Tasks
{
    class Task1
    {
        public static void DoWork()
        {
            Console.WriteLine("ZADANIE 1\n");

            var people = new MyList<Person>();

            people.Add(new Person("Jan", "Kowalski", 12));
            people.Add(new Person("Ala", "Nowak", 32));
            people.Add(new Person("Maja", "Marchewka", 14));
            people.Add(new Person("Jakub", "Kowalski", 17));
            people.Add(new Person("Janusz", "Nosacz", 65));

            Console.WriteLine($"Unchanged list of people: ");
            PrintPeople(people);

            Console.WriteLine($"Adults: ");
            for (uint i = 0; i < people.Count; i++)
            {
                if(people[i].Age >= 18)
                    Console.WriteLine(people[i].ToString());
            }

            try
            {
                Console.WriteLine("\nInsert at 1:");
                people.Insert(1, new Person("Dawid", "Wąski", 24));
                PrintPeople(people);

                Console.WriteLine("Insert at the beginning:");
                people.Insert(0, new Person("Damian", "Burzyński", 15));
                PrintPeople(people);

                Console.WriteLine("Insert at the end:");
                people.Insert(people.Count - 1, new Person("Kinga", "Glińska", 15));
                PrintPeople(people);

                Console.WriteLine("Remove first: ");
                people.RemoveAt(0);
                PrintPeople(people);

                Console.WriteLine("Remove last: ");
                people.RemoveAt(people.Count - 1);
                PrintPeople(people);

                Console.WriteLine("Remove Maja Marchewka element: ");
                people.Remove(new Person("Maja", "Marchewka", 14));
                PrintPeople(people);

                Console.WriteLine("Try to remove non-existing person: ");
                people.Remove(new Person("Sławomir", "Nieistnieje", 14));
                PrintPeople(people);

            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine("Try to access invalid index 99:");
                Console.WriteLine(people[99]);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
            Console.Clear();
        }

        private static void PrintPeople(MyList<Person> people)
        {
            for (uint i = 0; i < people.Count; i++)
            {
                Console.WriteLine(people[i].ToString());
            }
            Console.WriteLine();
        }
    }
}
