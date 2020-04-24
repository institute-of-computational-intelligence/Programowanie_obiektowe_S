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

        public Mammal(string typeOfFood, int legsCount, string origin, string species, string naturalHabitat) : base(typeOfFood, legsCount, origin, species)
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
