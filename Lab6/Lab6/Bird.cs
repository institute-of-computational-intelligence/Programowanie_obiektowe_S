using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Bird : Animal, IInfo
    {
        public double Wingspan { get; set; }
        public double Endurance { get; set; }

        public Bird(string foodType, string origin, string species, double wingspan, double endurance)
            : base(foodType, origin, species)
        {
            Wingspan = wingspan;
            Endurance = endurance;
        }

        public double MaxFlightLength()
        {
            return Wingspan * Endurance;
        }

        public override string ToString()
        {
            return $"Bird\n" + base.ToString() + $"Wingspan:{Wingspan}, Endurance:{Endurance}," +
                $"Maximum flight lenght without rest:{MaxFlightLength()}\n";
        }
        public override void Details()
        {
            Console.WriteLine(this);
        }
    }
}
