using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Reptiles : Animal
    {
        public string Type { get; set; }
        public string Food { get; set; }
        public string Origin { get; set; }

        public bool Venomous { get; set; }
        Cage cage = new Cage();
        public Reptiles (string food, int id, string origin, string type, bool venomous)
        {
            Food = food;
            cage.Id = id;
            Origin = origin;
            Type = type;
            Venomous = venomous;
        }
    }
}
