using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Bird : Animal
    {
        private double wingspan;
        private double strength;

        public Bird()
        {
        }

        public Bird(string species, int food, string origin, string suborder, double wingspan, double strength): base(species, food, origin, suborder)
        {
            this.wingspan = wingspan;
            this.strength = strength;
        }

        public void fly()
        {
            Console.WriteLine("Ptaszek lata");
        }

        public double MaximumFlightDistance()
        {
            return wingspan * strength;
        }

        public double Wingspan { get => wingspan; set => wingspan = value; }
        public double Strength { get => strength; set => strength = value; }

        public override string ToString()
        {
            return $"Ptak: {base.Species} {base.Food} {wingspan} {strength}";
        }
    }
}
