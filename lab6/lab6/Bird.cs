using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab6
{
    public class Bird : Animal
    {
        public float Wingspan { get; set; }
        public int Strength { get; set; }

        public float FlyDistance
        {
            get { return Wingspan*Strength; }
        }

        public Bird(string food, int age, string origin, string species, float wingspan, int strength) :
            base(food, age, origin, species)
        {
            Wingspan = wingspan;
            Strength = strength;
        }
        public override string ToString()
        {
            return base.ToString() + $"Rozpiętość skrzydeł: {Wingspan}, Zasięg lotu: {FlyDistance}";
        }
    }
}