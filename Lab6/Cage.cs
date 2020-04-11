using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Cage
    {
        private int id;
        private int capacity;
        private bool dirty;
        private List<Animal> animals = new List<Animal>();

        private static int globalID = 0;

        public Cage(int capacity, bool dirty, List<Animal> animals)
        {
            id = globalID++;
            this.capacity = capacity;
            this.dirty = dirty;
            this.animals = animals;
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

        public override string ToString()
        {
            return $"Klatka {id} {(dirty?"wymaga sprzatania":"czysta")} pojemnosc: {capacity} zwierzeta: "+String.Join(", ",animals);
        }
    }
}
