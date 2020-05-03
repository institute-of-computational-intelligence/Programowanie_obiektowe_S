using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        static void Main()
        {
            SinglyList<Person> list = new SinglyList<Person>();
            Person[] persons = new Person[12]
            {
                new Person("Jan", "Kowalski", 12),
                new Person("Agnieszka", "Cypis", 24),
                new Person("Monika", "Ptak", 8),
                new Person("Wojciech", "Broniewski", 62),
                new Person("Michal", "Dlug", 14),
                new Person("Adam", "Kowal", 18),
                new Person("Agata", "Duch", 19),
                new Person("Janek", "Kowalski", 35),
                new Person("Ala", "Nowak", 32),
                new Person("Maja", "Marchewka", 14),
                new Person("Jakub", "Kowalski", 17),
                new Person("Janusz", "Nosacz", 65)
            };

            list.Add(persons[0]);
            list.Add(persons[1]);
            list.Add(persons[2]);
            list.Add(persons[3]);
            list.Add(persons[4]);
            list.Add(persons[5]);
            list.Add(persons[6]);
            list.Add(persons[7]);
            list.Add(persons[8]);
            list.Add(persons[9]);

            Console.WriteLine("\nosoby:");
            int i = 0;
            foreach(var e in list)
                Console.WriteLine($"\t[{++i}]=> {e}");

            Console.WriteLine("\nosoby:");
            i = 0;
            try
            {
                list.Remove(persons[8]);
                list.RemoveAt(3);
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (var e in list)
                Console.WriteLine($"\t[{++i}]=> {e}");

            Console.WriteLine("\nosoby:");
            i = 0;
            try
            {
                list.Insert(7, persons[10]);
                list.Insert(0, persons[11]);
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (var e in list)
                Console.WriteLine($"\t[{++i}]=> {e}");

            Console.WriteLine("\nkobiety:");
            var sublist = list.Where(e => e.Name.EndsWith("a"));
            sublist.ToList().ForEach(e => Console.WriteLine(e));
            Console.WriteLine("\npelnoletni:");
            var pelnoletni = list.Where(e => e.Age >= 18);
            pelnoletni.ToList().ForEach(e => Console.WriteLine(e));

            Console.ReadKey();
        }
    }
}
