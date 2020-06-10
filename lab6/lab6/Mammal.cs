using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    class Mammal : Animal
    {
        private string naturalHabitat;

        public Mammal()
        {
            naturalHabitat = "--";
        }

        public Mammal(string species_, string food_, string orgin_, string natural_) :
            base(species_, food_, orgin_)
        {
            naturalHabitat = natural_;
        }

        public override string ToString()
        {
            return base.ToString() + $"Type: Mammal\r\n\tNatural Habitat {naturalHabitat}";
        }

        public override void Details()
        {
            Console.WriteLine(this);
        }
    }
}
