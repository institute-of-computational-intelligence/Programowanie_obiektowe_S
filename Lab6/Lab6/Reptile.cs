using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Reptile : Animal, IInfo
    {
        public bool Venomous { get; set; }
        public Reptile(string foodType, string origin, string species, bool venomous) : base(foodType, origin, species)
        {
            Venomous = venomous;
        }

        public override string ToString()
        {
            return $"Reptile\n" + base.ToString() + $"Venomous:{(Venomous ? "Yes" : "No")}\n";
        }

        public override void Details()
        {
            Console.WriteLine(this);
        }
    }
}
