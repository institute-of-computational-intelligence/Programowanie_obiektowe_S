using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_6
{
    class Task1
    {
        public static void DoWork()
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


            Employee employee1 = new CageSupervisor("Jan", "Kowalski", new DateTime(1990, 1, 1), DateTime.Now, cages);
            Employee employee2 = new CageSupervisor("Adam", "Nowak", new DateTime(1988, 1, 1), DateTime.Now, cages);

            Console.ReadKey();
        }
    }
}
