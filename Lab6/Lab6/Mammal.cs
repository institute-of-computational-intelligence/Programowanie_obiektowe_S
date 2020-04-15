using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public class Mammal : Animal
    {
        public string NaturalEnvironment { get; set; }
        public Mammal(string species, string food, string origin, string naturalEnvironment) 
            : base(species, food, origin)
        {
            NaturalEnvironment = naturalEnvironment;
        }


    }
}
