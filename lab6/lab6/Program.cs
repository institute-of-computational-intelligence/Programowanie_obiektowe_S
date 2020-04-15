using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo("Slaski ogrod zoologiczny");
            Animal dog = new Mammals("flesh", 4, "Europe", "Gray Wolf", "Europe");
            Animal cow = new Mammals("grass", 4, "Europe", "B. taurus", "Europe");
            Animal crocodile1 = new Reptiles("flesh", 4, "Africa", "C. niloticus", false);
            
            var animals1 = zoo.Set<Animal, Zoo>().AddRange(new List<Animal>
            {
            dog, cow, crocodile1
            });
            Cage cage1 = new Cage(4, false, animals1);
            cage1.Display();
            Animal horse = new Mammals("Grass", 4, "North America, Europe", "E.ferus", "Europe");
           
            Animal falcon = new Birds("flesh", 2, "Europe", "Falconidae", 1.2, 125);
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
            var employees = zoo.Set<Employee, Zoo>().AddRange(new List<Employee>()
            {
            employee1,
            employee2
            });
            Animal cobra = new Reptile("flesh", 0, "Africa", "Serpentes", true);
            Cage cage4 = zoo.BuildCage(10, false);
            var newEmploee = zoo.HireEmployee("Robert", "Kowalczyk", new DateTime(1988, 1, 1));
            ((CageSupervisor)newEmploee).Set<Cage, CageSupervisor>().Add(cage4);
            cage4.Set<Animal, Cage>().Add(cobra);
            zoo.Set<Cage, Zoo>().Add(cage4);
            zoo.ExpandCage(cage4, 5);
            Console.WriteLine();
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine();
            employees.PrintInfo();
            Console.WriteLine();
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine();
            Console.WriteLine();
            zoo.Print();
            Console.WriteLine();
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine();
            zoo.DisplayAllCages();
            Console.WriteLine();
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine();
            zoo.Print();
            Console.ReadKey();
        }
    }
}
