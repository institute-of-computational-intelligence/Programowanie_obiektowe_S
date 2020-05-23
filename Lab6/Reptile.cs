using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab6
{
    public class Reptile : Animal
    {
        public Reptile(bool isVirulent_, string kindOfFood_, string origin_, string species_) : base(kindOfFood_, origin_, species_)
        {
            IsVirulent = isVirulent_;
        }

        public bool IsVirulent { get; }

        public override string ToString()
        {
            return base.ToString() + $", virulent: {IsVirulent}";
        }
    }
}