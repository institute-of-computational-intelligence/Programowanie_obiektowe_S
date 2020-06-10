using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    class Zoo
    {
        private string name;

        private List<Animal> Animals = new List<Animal>();
        private List<Cage> Cages = new List<Cage>();
        private List<Worker> Workers = new List<Worker>();

        public Zoo()
        {
            name = "--";
        }

        public Zoo(string name_)
        {
            name = name_;
        }

        public Cage ConstructCage(int amount_)
        {
            Cage newCage = new Cage(amount_);
            AddCage(newCage);
            return newCage;
        }

        public void MakeBiggerCage(Cage c, int newAmount_)
        {
            c.Amount = newAmount_;
        }

        public void HireWorker(Worker w)
        {
            Workers.Add(w);
        }

        public void AddAnimal(Animal a, Cage c)
        {
            c.AddAnimal(a);
        }

        public void AddCage(Cage c)
        {
            Cages.Add(c);
        }

        public void DirtyCages()
        {
            foreach (Cage c in Cages)
            {
                if (c.Clean == false)
                    Console.WriteLine("Cage with ID " + c.ID + " is dirty");
            }
        }

        public void CleanCage(Cage c)
        {
            c.Clean = true;
        }

        public void Details()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("Zoo: " + name);
            foreach (Worker w in Workers)
            {
                Console.WriteLine("\n");
                w.Details();
                Console.WriteLine("\n");
            }                
        }
    }
}
