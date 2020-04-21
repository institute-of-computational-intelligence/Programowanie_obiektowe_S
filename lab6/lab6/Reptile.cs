using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab6
{
    public class Reptile : Animal
    {
        public bool IsVenomous { get; set; }
        public Reptile(string food, int age, string origin, string species, bool isVenomous):
            base(food, age, origin, species)
        {
            IsVenomous = isVenomous;
        }
        public override string ToString()
        {
            if (IsVenomous == true)
                return base.ToString() + ", jadowity: TAK";
            else
                return base.ToString() + ", jadowity: NIE";
        }
    }
}