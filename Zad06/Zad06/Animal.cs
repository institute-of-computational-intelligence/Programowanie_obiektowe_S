using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad06
{
    class Animal
    {
        protected string species;
        protected string food;
        protected string origin;

        public Animal(string species, string food, string origin) {
            this.species = species;
            this.food = food;
            this.origin = origin;
        }

        public override string ToString()
        {
            return $"Animal| Species: {species}, food: {food}, orgin: {origin}";
        }

        public virtual void Details()
        {
            Console.WriteLine(this);
        }
    }
}
