using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab6
{
    public class Zoo
    {
        public string Name { get; }
        public List<Cage> Cages { get; set; } = new List<Cage>();
        public List<Kepeer> Kepeers { get; set; } = new List<Kepeer>();
        
        public Zoo(string name_)
        {
            Name = name_;
        }

        public void InfoCages()
        {
            foreach (var x in Cages)
                Console.WriteLine(x);
        }

        public void InfoKepeers()
        {
            foreach (var x in Kepeers)
                Console.WriteLine(x);
        }
    
        public void AddCage(int capacity)
        {
            if(Cages != null)
            {
                Cages.Add(new Cage(capacity, Cages.Count + 1));
            }
            else
            {
                Cages.Add(new Cage(capacity, 1));
            }
        }

        public void ExpandCage(int ID, int addedSpace)
        {
            foreach(var x in Cages)
            {
                if(x.Number == ID)
                {
                    x.Capacity += addedSpace;
                    break;
                }
            }
        }

        public void HireKepeer(Kepeer kepeer)
        {
            Kepeers.Add(kepeer);
        }
        
        public void AddAnimal(int ID, Animal animal)
        {
            bool cageExist = false;
            Cage cage = new Cage();
            foreach(var x in Cages)
            {
                if(x.Number == ID)
                {
                    cage = x;
                    cageExist = true;
                    break;
                }
            }
            if (cageExist)
            {
                cage.Animals.Add(animal);
            }
            else
            {
                AddCage(1);
                Cages[Cages.Count - 1].Animals.Add(animal);
            }
        }
    }
}