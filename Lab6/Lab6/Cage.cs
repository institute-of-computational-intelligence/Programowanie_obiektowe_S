using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab6.Interfaces;

namespace lab6
{
    public class Cage :IInfo
    {
        public double Capacity { get; set; }
        public int IdentificationNumner { get; set; }
        public bool RequiredCleaning { get; set; }
        public List<Animal> Animals { get; set; }

        private static int counter = 0;
        

        public Cage(double capacity, bool requiredCleaning, List<Animal> animals)
        {
            counter++;
            Capacity = capacity;
            IdentificationNumner = counter;
            RequiredCleaning = requiredCleaning;
            Animals = animals;
        }

        public void Display()
        {
            Console.WriteLine($"ID: {IdentificationNumner} Capacity: {Capacity}"
                + $"Requires cleanig: {(RequiredCleaning ? "yes" : "no")}");
            Console.WriteLine($"Amimals is this cage");
            foreach (var animal in Animals)
            {
                animal.Display();
            }
        }
    }
}
