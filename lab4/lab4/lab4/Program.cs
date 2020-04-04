using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ZADANIE1");
            var list = new MyList<Person>();

            list.Add(new Person("Jan", "kowalski", 12));
            list.Add(new Person("Ala", "Nowak", 32));
            list.Add(new Person("Maja", "Marchewka", 14));
            list.Add(new Person("Jakub", "kowalski", 27));

            Console.WriteLine("\nAdults:");
            
            for (int i=0; i<list.Quantity; i++)
            {
                if (list[i].Age >= 18)
                    Console.WriteLine($"\t{list[i]}");
            }
            list.RemoveAt(1);
            Console.WriteLine("\nAdults after remove one person:");

            for (int i = 0; i < list.Quantity; i++)
            {
                if (list[i].Age >= 18)
                    Console.WriteLine($"\t{list[i]}");
            }
            list.Insert(1, new Person("Daria", "Wisniewska", 22));

            Console.WriteLine("\nAdults after add one person:");

            for (int i = 0; i < list.Quantity; i++)
            {
                if (list[i].Age >= 18)
                    Console.WriteLine($"\t{list[i]}");
            }
            Console.WriteLine("\nAdults after remove one person:");
            
            list.Remove(new Person("Jakub", "kowalski", 27));
            for (int i = 0; i < list.Quantity; i++)
            {
                if (list[i].Age >= 18)
                    Console.WriteLine($"\t{list[i]}");
            }
            Console.WriteLine("ZADANIE2");

            
            var lista = new MyList<Person>
            {
            new Person("Jan", "kowalski",12),
            new Person("Ala", "Nowak", 32),
            new Person("Maja", "Marchewka", 14),
            new Person("Jakub", "kowalski",27)
            };
            Console.WriteLine("\nAdults:");
            foreach (var e in lista)
            {
                if (e.Age >= 18)
                    Console.WriteLine($"\t{e}");
            }
            lista.RemoveAt(1);
            Console.WriteLine("\nAdults after remove one person:");

            foreach (var e in lista)
            {
               if (e.Age >= 18)
                    Console.WriteLine($"\t{e}");
            }
            lista.Insert(1, new Person("Daria", "Wisniewska", 22));

            Console.WriteLine("\nAdults after add one person:");

            foreach (var e in lista)
            {
                if (e.Age >= 18)
                    Console.WriteLine($"\t{e}");
            }
            Console.WriteLine("\nAdults after remove one person:");

            lista.Remove(new Person("Jakub", "kowalski", 27));
            foreach (var e in lista)
            {
                if (e.Age >= 18)
                    Console.WriteLine($"\t{e}");
            }

            Console.ReadKey();
        }
    }
}
