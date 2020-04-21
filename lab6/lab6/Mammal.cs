using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab6
{
    public class Mammal : Animal
    {
        public string NaturalEnvironment { get; set; }
        public Mammal(string food, int age, string origin, string species, string naturalEnvironment) :
            base(food, age, origin, species)
        {
            NaturalEnvironment = naturalEnvironment;
        }
        public override string ToString()
        {
            return base.ToString() + $", naturalne środowisko: {NaturalEnvironment}";
        }
    }
}