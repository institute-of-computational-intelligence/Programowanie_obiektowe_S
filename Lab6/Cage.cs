using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Cage : IInfo, IAction
    {
        private int id;
        private int capacity;
        private bool dirty;
        private IList<Animal> animals = new List<Animal>();
        private CageSupervisor cageSupervisor;

        private static int globalID = 0;

        public Cage(int capacity, bool dirty, IList<Animal> animals, CageSupervisor cageSupervisor = null)
        {
            id = globalID++;
            this.capacity = capacity;
            this.dirty = dirty;
            this.animals = animals;
            this.cageSupervisor = cageSupervisor;
        }

        public Cage(int capacity, bool dirty = false)
        {
            id = globalID++;
            this.capacity = capacity;
            this.dirty = dirty;
        }

        public int Id { get => id; }
        public int Capacity { get => capacity; set => capacity = value; }
        public bool Dirty { get => dirty; set => dirty = value; }
        public CageSupervisor CageSupervisor { get => cageSupervisor; set => cageSupervisor = value; }
        public IList<Animal> Animals { get => animals; set => animals = value; }

        public override string ToString()
        {
            return $"Klatka {id} stan: {(dirty?"wymaga sprzatania":"czysta")} pojemnosc: {capacity} zwierzeta: "+String.Join(", ",animals);
        }

        public void DisplayInfo()
        {
            Console.WriteLine(this);
        }
    }
}
