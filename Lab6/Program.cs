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
            Animal dog = new Mammal("Europe", "flesh", "Europe", "Gray Wolf");
            Animal cow = new Mammal("Europe", "grass", "Europe", "B. taurus");
            Animal crocodile1 = new Reptile(false, "flesh", "Africa", "C. niloticus");
            zoo.AddCage(5);
            zoo.AddAnimal(1, dog);
            zoo.AddAnimal(2, cow);
            zoo.AddAnimal(3, crocodile1);
            zoo.ExpandCage(2, 2);

            Animal horse = new Mammal("North America, Europe", "Grass", "Europe", "E. ferus");
            Animal falcon = new Bird(1.2f, 125, "flesh", "Europe", "Falconidae");
            zoo.AddAnimal(2, horse);
            zoo.AddAnimal(3, falcon);

            Kepeer employee1 = new Kepeer("Jan", "Kowalski");
            Kepeer employee2 = new Kepeer("Adam", "Nowak", zoo.Cages);
            zoo.HireKepeer(employee1);
            zoo.HireKepeer(employee2);
            employee1.AddCage(zoo.Cages[0]);
            employee1.AddCage(zoo.Cages[2]);

            Animal cobra = new Reptile(true, "flesh", "Africa", "Serpentes");
            zoo.AddAnimal(3, cobra);

            zoo.InfoCages();
            Console.WriteLine("__________________________________________________________________");
            zoo.InfoKepeers();

            Console.ReadLine();
        }
    }
}
