using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad06
{
    class Reptile : Animal
    {
        bool poison;

        public Reptile(string species, string food, string origin, bool poison) : base(species, food, origin){
            this.poison = poison;
        }

        public override string ToString()
        {
            return base.ToString() + $"Type: Reptile\r\n\tPoisonous: {poison}";
        }

        public override void Details()
        {
            Console.WriteLine(this);
        }
    }
}
