using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("task 1: ");

            var queue = new MyList<Person>();

            queue.Add(new Person("adam", "mozak", 18));
            queue.Add(new Person("pawel", "kot", 15));
            queue.Add(new Person("kamila", "przak", 24));
            queue.Add(new Person("ania", "krak", 18));
            queue.Add(new Person("robert", "ptak", 13));

            Console.WriteLine("list of people: ");
            for (int i = 0; i < queue.Count; i++)
                Console.WriteLine(queue[i].ToString());


            queue.Insert(3, new Person("zuzanna", "xDDDDD", 36));
            queue.Insert(5, new Person("zygmunt", "asdasd", 23));

            Console.WriteLine("\nlist of people above 18: ");
            for (int i = 0; i < queue.Count; i++)
            {
                if (queue[i].Age>= 18)
                    Console.WriteLine(queue[i].ToString());
            }

            queue.RemoveAt(3);

            Console.WriteLine("task 2: ");

            var people = new MyList<Person>();

            people.Add(new Person("Jan", "Kowalski", 12));
            people.Add(new Person("Ala", "Nowak", 32));
            people.Add(new Person("Krzysztof", "Krawczyk", 14));
            people.Add(new Person("Jakub", "Kowalski", 17));
            people.Add(new Person("Jan", "Nowak", 65));

            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }

            Console.ReadKey();
        }
    }
}
