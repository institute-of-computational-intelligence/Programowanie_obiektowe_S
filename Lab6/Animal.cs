using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab6
{
    public abstract class Animal
    {
        public Animal(string kindOfFood_, string origin_, string species_)
        {
            Species = species_;
            Origin = origin_;
            KindOfFood = kindOfFood_;
        }

        public string Species { get; }

        public string KindOfFood { get; }

        public string Origin { get; }

        public override string ToString()
        {
            return $"Species: {Species}, Kind of food: {KindOfFood}, Origin: {Origin}";
        }
    }
}