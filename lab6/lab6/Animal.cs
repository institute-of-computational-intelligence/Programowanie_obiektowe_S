using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab6
{
    public class Animal
    {
        public string Species { get; set; }
        public string Origin { get; set; }
        public string Food { get; set; }
        public int Age { get; set; }

        public Animal(string food, int age, string origin, string species)
        {
            Food = food;
            Age = age;
            Origin = origin;
            Species = species;
        }

        public override string ToString()
        {
            return $"Gatunek: {Species}, wiek: {Age}, pożywienie: {Food}, pochodzi z: {Origin}";
        }

    }
}