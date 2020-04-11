using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Reptile: Animal
    {
        private bool venomous;

        public Reptile():base()
        {
            
        }

        public Reptile(string species, int food, string origin, string suborder, bool venomous) : base(species, food, origin, suborder)
        {
            this.venomous = venomous;
        }

        public bool Venomous { get => venomous; set => venomous = value; }

        public override string ToString()
        {
            return $"Gad {base.Species}, podrząd: {base.Suborder} rodz. pozywienia: {base.Food} {base.Origin} {(venomous ? "jadowity" : "")}";
        }
    }
}
