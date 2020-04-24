using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06
{
    class Bird : Animal
    {
        public double Wingspan { get; set; }
        public double Endurance { get; set; }

        public Bird(string species, int legsCount, string typeOfFood, string origin, double wingspan, double endurance) : base(typeOfFood, legsCount, origin, species)
        {
            Wingspan = wingspan;
            Endurance = endurance;
        }

        public override string ToString()
        {
            return base.ToString() + $", wingspan {Wingspan}, endurance {Endurance}, flight duration {GetFlightDuration()} minutes";
        }

        public double GetFlightDuration()
        {
            return Wingspan * Endurance;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine(this);
        }
    }
}
