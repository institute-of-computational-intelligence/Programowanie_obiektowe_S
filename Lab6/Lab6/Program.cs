using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo("Slaski ogrod zoologiczny"); 
            Animal dog = new Mammal("flesh", "Europe", "Gray Wolf", "Europe");
            Animal cow = new Mammal("grass", "Europe", "B. taurus", "Europe");
            Animal crocodile1 = new Reptile("flesh",  "Africa", "C. niloticus", false);
            var animals1 = zoo.Set<Animal, Zoo>().AddRange(new List<Animal> { dog, cow, crocodile1 });
            Cage cage1 = new Cage(4, false, animals1); 
            cage1.Details();
            Employee employee1 = new CageSupervisor("Jan", "Kowalski", new DateTime(1990, 1, 1), DateTime.Now, cages1);
            Employee employee2 = new CageSupervisor("Adam", "Nowak", new DateTime(1988, 1, 1), DateTime.Now, cages2);
            Console.ReadKey();
        }
    }
}
