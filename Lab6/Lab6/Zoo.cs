using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab6.Interfaces;

namespace lab6
{
    public class Zoo :IAction
    {
        public string Name { get; set; }
        public List<Cage> Cages;
        public List<Worker> Workers;

       public Zoo(string name)
        {
            Name = name;
            Cages = new List<Cage>();
            Workers = new List<Worker>();

        }    

        public Cage AddCage(double capacity, bool reqiuresCleaning)
        {
            return new Cage(capacity, reqiuresCleaning, new List<Animal>());
        }

        public void ExpandCage(Cage cage, double newCapacity)
        {
            cage.Capacity = newCapacity;
        }

        public Worker AddWorker(string name, string surname, DateTime dateOfBirth)
        {
            return new Worker(name, surname, dateOfBirth, DateTime.UtcNow);
        }

        public void AddAnimalToCage(Cage cage, Animal animal)
        {
            cage.Animals.Add(animal);
        }

    }
}
