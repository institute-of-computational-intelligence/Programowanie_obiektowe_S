using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Mammal: Animal
    {
        private string naturalEnvironment;

        public Mammal(): base()
        {
            
        }

        public Mammal(string species, int food, string origin, string suborder, string naturalEnvironment) : base(species, food, origin, suborder)
        {
            this.naturalEnvironment = naturalEnvironment;
        }

        public string NaturalEnvironment { get => naturalEnvironment; set => naturalEnvironment = value; }

        public override string ToString()
        {
            return $"Ssak {base.Species}, podrząd {base.Suborder}, rodz. pozywienia: {base.Food} {naturalEnvironment}";
        }
    }
}
