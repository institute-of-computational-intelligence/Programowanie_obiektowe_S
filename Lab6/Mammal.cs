using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab6
{
    public class Mammal : Animal
    {
        public Mammal(string environment_, string kindOfFood_, string origin_, string species_) : base(kindOfFood_, origin_, species_)
        {
            Environment = environment_;
        }

        public string Environment { get; }

        public override string ToString()
        {
            return base.ToString() + $", Environment: {Environment}";
        }
    }
}