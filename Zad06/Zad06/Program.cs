using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Zad06
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo("Śląski Ogród Zoologiczny");

            Animal dog = new Mammal("Gray Wolf", "meat", "Europe", "Europe");
            Animal cow = new Mammal("B. Taurus", "grass", "Europe", "Europe");
            Animal crocodile = new Reptile("C. Niloticus", "flesh", "Africa", false);
            Animal bird = new Bird("Magpie", "wheat", "Europe", 40, 12);

            Cage c1 = zoo.ConstructCage(2);
            Cage c2 = zoo.ConstructCage(2);

            zoo.AddAnimal(dog, c1);
            zoo.AddAnimal(cow, c1);
            zoo.AddAnimal(crocodile, c1);

            zoo.MakeBiggerCage(c1, 6);

            zoo.AddAnimal(dog, c1);
            zoo.AddAnimal(cow, c1);
            zoo.AddAnimal(crocodile, c1);

            zoo.AddAnimal(bird, c2);
            zoo.AddAnimal(bird, c2);

            Worker w1 = new Worker("Pracownik jeden");
            Worker w2 = new Worker("Pracownik dwa");

            zoo.HireWorker(w1);
            zoo.HireWorker(w2);

            w1.AddCage(c1);
            w2.AddCage(c2);

            c2.Clean = false;

            zoo.Details();
            zoo.DirtyCages();
            zoo.CleanCage(c2);
            zoo.DirtyCages();

            Console.ReadKey();
        }
    }
}
