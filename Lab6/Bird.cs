using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab6
{
    public class Bird : Animal
    {
        public Bird(float wingspan_, float strength_, string kindOfFood_, string origin_, string species_) : base(kindOfFood_, origin_, species_)
        {
            Wingspan = wingspan_;
            Strength = strength_;
            FlightTime = wingspan_ * strength_;
        }

        public float FlightTime { get; }

        public float Wingspan { get; }

        public float Strength { get; }

        public override string ToString()
        {
            return base.ToString() + $", Wingspan: {Wingspan}, Strenght: {Strength}, Flight time: {FlightTime}";
        }
    }
}