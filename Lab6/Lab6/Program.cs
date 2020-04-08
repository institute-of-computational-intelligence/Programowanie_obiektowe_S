using System;
using System.Collections.Generic;
using Lab6.Interfaces;
using Lab6.Extensions;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo("Slaski ogrod zoologiczny");
            Animal dog = new Mammal("flesh", "Europe", "Gray Wolf", "Europe");
            Animal cow = new Mammal("grass",  "Europe", "B. taurus", "Europe");
            Animal crocodile1 = new Reptile("flesh", "Africa", "C. niloticus", false);
           
            var animals1 = zoo.Set<Animal, Zoo>().AddRange(new List<Animal>
             {
                dog, cow, crocodile1
             });
            
            Cage cage1 = new Cage(4, false, animals1);
            
            cage1.Display();
            
            Animal horse = new Mammal("Grass", "North America, Europe", "E.ferus", "Europe");
           
            Animal falcon = new Bird("flesh", "Europe", "Falconidae", 1.2, 125);
            var animals2 = zoo.Set<Animal, Zoo>().AddRange(new List<Animal>()
            {
                 horse,
                 falcon
            });
            
            Cage cage2 = new Cage(3, false, animals2);
            
            cage2.Display();

            Cage cage3 = new Cage(10, false, new List<Animal>());
            
            var cages1 = zoo.Set<Cage, Zoo>().AddRange(new List<Cage>()
            {
                 cage1,
                 cage2
            });
            
            var cages2 = zoo.Set<Cage, Zoo>().AddRange(new List<Cage>()
            {
                cage3
            });

            Employee employee1 = new CageSupervisor("Jan", "Kowalski", new DateTime(1990, 1, 1), DateTime.Now, cages1);
            Employee employee2 = new CageSupervisor("Adam", "Nowak", new DateTime(1988, 1, 1), DateTime.Now, cages2);

            Console.ReadKey();
        }
    }
}
