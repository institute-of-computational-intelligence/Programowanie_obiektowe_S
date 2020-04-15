using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Mammals : Animal
    {
        public string Type { get; set; }
        public string Food { get; set; }
        public string Origin { get; set; }
        public string Natural_environment { get; set; }
        Cage cage = new Cage();

        public Mammals(string food, int id, string origin, string type, string natural_environment)
        {
            Food = food;
            cage.Id = id;
            Origin = origin;
            Type = type;
            Natural_environment = natural_environment;
        }
    }
}
