using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad04 {
    class Program {
        static void Main(string[] args) {
            Person p1 = new Person("Jan", "Kowalski", 25);
            Person p2 = new Person("Ala", "Nowak", 17);
            Person p3 = new Person("Jakub", "Nowacki", 31);
            Person p4 = new Person("Pawel","Grzybacki", 24);
            MyList<Person> myList = new MyList<Person>();
            myList.Add(p1);
            myList.Add(p2);
            myList.Add(p3);  
            myList.Insert(1, p4);
            Console.WriteLine($"Unchanged list of people: ");
            foreach (Person p in myList) {
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine($"Adults: ");
            foreach (Person p in myList) {
                if (p.Age >= 18)
                    Console.WriteLine(p.ToString());
            }
            Console.WriteLine("Remove first: ");
            myList.RemoveAt(0);
            foreach (Person p in myList) {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("Remove last: ");
            myList.RemoveAt(myList.Size - 1);
            foreach (Person p in myList) {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("Remove p2: ");
            myList.Remove(p2);
            foreach (Person p in myList) {
                Console.WriteLine(p.ToString());
            }
            Console.ReadKey();
        }
    }
}
