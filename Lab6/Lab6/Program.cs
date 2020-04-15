using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab6.Interfaces;

namespace lab6
{
    public class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo("Slaski ogrod zoologiczny");
            Animal dog = new Mammal("flesh", "Europe", "Gray Wolf", "Europe");
            Animal cow = new Mammal("grass", "Europe", "B. taurus", "Europe");
            Animal crocodile1 = new Reptile("flesh", "Africa", "C. niloticus", false);

            var animals = new List<Animal> { dog, cow, crocodile1 };

            Cage cage1 = new Cage(4, false, animals);

            var cages = new List<Cage> { cage1 };

            Animal horse = new Mammal("Grass", "North America, Europe", "E.ferus", "Europe");

            Animal falcon = new Bird("flesh", "Europe", "Falconidae", 125, 1.2);


            Worker employee1 = new CageCleaner("Jan", "Kowalski", new DateTime(1990, 1, 1), DateTime.Now, cages);
            Worker employee2 = new CageCleaner("Adam", "Nowak", new DateTime(1988, 1, 1), DateTime.Now, cages);

            Console.ReadKey();
        }
    }
}
