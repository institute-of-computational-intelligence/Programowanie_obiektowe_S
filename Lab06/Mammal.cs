using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06
{
    class Mammal : Animal
    {
        public string NaturalHabitat { get; set; }

        public Mammal(string species, string typeOfFood, string origin, string naturalHabitat) : base(species, typeOfFood, origin)
        {
            NaturalHabitat = naturalHabitat;
        }

        public override string ToString()
        {
            return base.ToString() + $", natural habitat: {NaturalHabitat}";
        }

        public override void DisplayInfo()
        {
            Console.WriteLine(this);
        }
    }
}
