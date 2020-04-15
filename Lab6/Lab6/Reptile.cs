using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public class Reptile : Animal
    {
        public bool IsPoisoned { get; set; }
        public Reptile(string species, string food, string origin, bool isPoisoned) 
            : base(species, food, origin)
        {
            IsPoisoned = isPoisoned;
        }
    }
}
