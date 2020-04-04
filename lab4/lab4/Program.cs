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
            var list = new MyList<Person>
            {
                new Person("Jan", "kowalski",12),
                new Person("Ala", "Nowak", 32),
                new Person("Maja", "Marchewka", 14),
                new Person("Jakub", "kowalski",27)
            };
            Console.WriteLine("\nWszyscy:");
            foreach (var e in list)
            {
                Console.WriteLine($"\t{e}");
            }

            list.RemoveAt(1);
            Console.WriteLine("po usunieciu po indeksie:");
            foreach (var e in list)
            {
                Console.WriteLine($"\t{e}");
            }

            list.Remove(list[1]);
            Console.WriteLine("po usunieciu po elemencie:");
            foreach (var e in list)
            {
                Console.WriteLine($"\t{e}");
            }

            Person nowa = new Person("Sebastian", "Jarzabek", 22);
            list.Insert(0, nowa);
            Console.WriteLine("po dodaniu:");
            foreach (var e in list)
            {
                Console.WriteLine($"\t{e}");
            }
            list.Insert(1, nowa);
            Console.WriteLine("po dodaniu:");
            foreach (var e in list)
            {
                Console.WriteLine($"\t{e}");
            }
            
        }
    }
}
