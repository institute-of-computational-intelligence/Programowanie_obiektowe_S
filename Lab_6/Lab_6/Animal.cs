using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_6
{
    public class Animal
    {
        public string Species { get; }
        public string Food { get;  }
        public string Origin { get;  }
        public Animal(string species, string food, string origin)
        {
            Species = species;
            Food = food;
            Origin = origin;
        }
    }
}
