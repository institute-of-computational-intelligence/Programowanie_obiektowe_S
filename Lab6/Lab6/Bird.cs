using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public class Bird : Animal
    {

        public double Wingspan { get; set; }
        public double Strength { get; set; }

        public Bird(string species, string food, string origin, double wingspan, double strength) 
            : base(species, food, origin)
        {
            Wingspan = wingspan;
            Strength = strength;
        }

        public void MaxFly(double wingspan, double strength)
        {
            Console.WriteLine($"Flew: {Wingspan * Strength} "); 
        }
    }
}
