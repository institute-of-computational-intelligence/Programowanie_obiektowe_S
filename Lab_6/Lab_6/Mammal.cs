using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_6
{
    public class Mammal: Animal
    {
        public string NaturalHabitat { get; }
        public Mammal(string species,string food,string origin,string naturalHabitat):
            base(species,food,origin)
        {
            NaturalHabitat = naturalHabitat;
        }
    }
}
