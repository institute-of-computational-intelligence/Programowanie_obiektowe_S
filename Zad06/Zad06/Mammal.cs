using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Zad06
{
    class Mammal : Animal
    {
        private string naturalHabitat;

        public Mammal(string species, string food, string origin, string naturalHabitat) : base(species, food, origin){
            this.naturalHabitat = naturalHabitat;
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
