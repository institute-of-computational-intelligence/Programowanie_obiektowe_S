using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_6
{
    public class Reptile: Animal
    {
        public bool IsVenomous { get; }

        public Reptile(string species,string food,string origin,bool isVenomous):
            base(species,food,origin)
        {
            IsVenomous = isVenomous;
        }
    }
}
