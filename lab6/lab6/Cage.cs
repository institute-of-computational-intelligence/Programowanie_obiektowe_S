using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab6
{
    public class Cage
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public bool NeedsCleaning { get; set; }
        public IList<Animal> Animals { get; set; }

        private readonly int cageCount = 0;
        public Cage(int capacity, bool needsCleaning, List<Animal> animals)
        {
            cageCount++;
            Id = cageCount;
            Capacity = capacity;
            NeedsCleaning = needsCleaning;
            Animals = animals;
        }

        public override string ToString()
        {
            string str = $"Klatka nr {Id}, pojemność: {Capacity}";
            if (NeedsCleaning == true)
                str += $" , WYMAGANE SPRZĄTANIE";
            str += $"\nZwierzęta znajdujące się w klatce: ";
            foreach (Animal item in Animals)
            {
                str += $"\n\t{item}";
            }
            return str;
        }
    }
}