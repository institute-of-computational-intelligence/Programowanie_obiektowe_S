using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab6
{
    public class Cage
    {
        public Cage(int capacity_, int number_)
        {
            CleanUpNeeded = false;
            Capacity = capacity_;
            Number = number_;
        }

        public Cage()
        {
            CleanUpNeeded = false;
            Capacity = 0;
            Number = 0;
        }

        public bool CleanUpNeeded { get; set; }

        public int Capacity { get; set; }

        public int Number { get; }

        public List<Animal> Animals { get; set; } = new List<Animal>();

        public override string ToString()
        {
            string info = $"Number: {Number}, Clean up needed: {CleanUpNeeded}\nList of animals in cage:\n";
            foreach(var x in Animals)
            {
                info += $"{x}\n";
            }
            return info;
        }
    }
}