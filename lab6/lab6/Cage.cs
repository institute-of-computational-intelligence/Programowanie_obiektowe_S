using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    class Cage
    {
        private static int id = 0;
        private int amount = 0;
        private bool clean;
        private List<Animal> animals = new List<Animal>();

        public Cage() 
        {
            id++;
        }

        public Cage(int amount_)
        {
            id++;
            amount = amount_;
            clean = true;
        }

        public Cage(int amount_, bool clean_, List<Animal> animals_)
        {
            id++;
            amount = amount_;
            clean = clean_;
            animals = animals_;
        }

        public int ID { get => id; set => id = value; }
        public bool Clean { get => clean; set => clean = value; }
        internal List<Animal> Animals { get => animals; set => animals = value; }
        public int Amount { get => amount; set => amount = value; }

        public void AddAnimal(Animal a)
        {
            if (animals.Count < amount)
            {
                animals.Add(a);
                Console.WriteLine("pmoyślnie dodano zwierze do klatki");
            }                
            else
                Console.WriteLine("przekroczono limit zwierząt w klatce");
        }

        public override string ToString()
        {
            return $"Cage | ID: {id}, {(clean ? "clean," : "needs cleaning,")} amount: {amount}";
        }

        public void Details()
        {
            Console.WriteLine(this);
            foreach (Animal a in animals)
                a.Details();
        }
    }
}
