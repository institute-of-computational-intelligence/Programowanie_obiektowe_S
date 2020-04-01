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
        }
    }
}
