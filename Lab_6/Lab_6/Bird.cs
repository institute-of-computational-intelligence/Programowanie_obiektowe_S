using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_6
{
    public class Bird : Animal
    {
        public int Endurance { get;  }
        public double Wingspan { get; set; }

        public Bird(string species, string food, string origin, int endurance, double wingspan) :
            base(species,food,origin)
        {
            Endurance = endurance;
            Wingspan = wingspan;
        }

        public void Fly()
        {
            Console.WriteLine($"Ptak przebyl dystans {Endurance*Wingspan}");
        }
    }
}
