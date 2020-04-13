using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Mammal : Animal, IInfo
    {
        public string NaturalHabitat { get; set; }
        public Mammal(string foodType, string origin, string species, string naturalEnviroment) : base(foodType, origin, species)
        {
            NaturalHabitat = naturalEnviroment;
        }

        public override string ToString()
        {
            return $"Mammal\n" + base.ToString() + $"Natural enviroment of this mammal is:{NaturalHabitat}\n";
        }

        public override void Details()
        {
            Console.WriteLine(this);
        }
    }
}
