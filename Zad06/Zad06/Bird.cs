using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad06
{
    class Bird : Animal
    {
        private double wingsWidth;
        private double endurance;

        public Bird(string species, string food, string origin, double wingsWidth, double endurance): base(species, food, origin) {
            this.wingsWidth = wingsWidth;
            this.endurance = endurance;
        }

        public double MaxFlyTime()
        {
            return wingsWidth * endurance;
        }

        public override string ToString()
        {
            return base.ToString() + $"Type: Bird\r\n\tWings Width: {wingsWidth}, endurance: {endurance}";
        }

        public override void Details()
        {
            Console.WriteLine(this);
        }
    }
}
