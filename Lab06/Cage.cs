using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06
{
    class Cage : IInfo
    {
        private static int IDs = 0;
        public int Identificator { get; set; }
        public int Capacity { get; private set; }
        public bool IsClean { get; set; } = true;
        public IList<Animal> AnimalsInCage { get; }

        public Cage(int capacity, bool clean)
        {
            Capacity = capacity;
            IsClean = clean;
            Identificator = IDs++;

            AnimalsInCage = new List<Animal>();
        }

        public Cage(int capacity, bool clean, Animal animal) : this(capacity, clean)
        {
            if (capacity > 0 && animal != null)
                AnimalsInCage.Add(animal);

        }

        public void ResizeCage(int newCapacity)
        {
            if (newCapacity < Capacity) Console.WriteLine("New capacity cannot be smaller!");
            else Capacity = newCapacity;
        }

        public override string ToString()
        {
            string baseStr = $"Cage ID {Identificator}, capacity {Capacity}, requires cleaning up: {(IsClean ? "Yes" : "No")}, animals in cage:\r\t";
            foreach (Animal animal in AnimalsInCage)
                baseStr += animal + "\r\t";

            return baseStr;
        }

        public void PutAnimalInCage(Animal animal)
        {
            if (animal == null) return;
            if (AnimalsInCage.Count == Capacity) Console.WriteLine($"Could not add {animal}, cage {Identificator} is full!");
            else if (!AnimalsInCage.Contains(animal))
                AnimalsInCage.Add(animal);
            else Console.WriteLine($"{animal} is already in cage {Identificator}!");
        }

        public void DisplayInfo()
        {
            Console.WriteLine(this);
        }
    }
}
