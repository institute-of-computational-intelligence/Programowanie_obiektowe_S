using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    class Bird : Animal
    {
        private double wingsWidth;
        private double endurance;

        public Bird()
        {
            wingsWidth = 0;
            endurance = 0;
        }

        public Bird(string species_, string food_, string orgin_, double wingsWidth_, double endurance_) :
            base (species_, food_, orgin_)
        {
            wingsWidth = wingsWidth_;
            endurance = endurance_;
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
