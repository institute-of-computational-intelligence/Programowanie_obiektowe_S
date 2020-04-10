﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06
{
    class Zoo : IInfo
    {
        public string ZooName { get; set; }
        public IList<Cage> Cages { get; }
        public IList<Maintainer> Maintainers { get; }

        public Zoo(string zooName)
        {
            ZooName = zooName;
            Cages = new List<Cage>();
            Maintainers = new List<Maintainer>();
        }

        Cage ConstructCage(int capacity)
        {
            Cages.Add(new Cage(capacity, true));
            return Cages.Last();
        }

        Maintainer HireEmployee(string name, string surname)
        {
            Maintainers.Add(new Maintainer(name, surname));
            return Maintainers.Last();
        }

        public void ExpandCage(int cageID, int newCapacity)
        {
            Cage cage = ((List<Cage>)Cages).Find(x => x.Identificator == cageID);

            if (cage != null) cage.ResizeCage(newCapacity);
        }

        public void ExpandCage(Cage cage, int newCapacity)
        {
            if (cage != null) cage.ResizeCage(newCapacity);
        }

        public void AddAnimal(int cageID, Animal animal)
        {
            if (animal == null) return;

            Cage cage = ((List<Cage>)Cages).Find(x => x.Identificator == cageID);
            if (cage != null) cage.PutAnimalInCage(animal);

        }

        public void AddAnimal(Cage cage, Animal animal)
        {
            if (cage != null) cage.PutAnimalInCage(animal);
        }

        public override string ToString()
        {
            return $"Zoo name: {ZooName}";
        }


        public void DisplayInfo()
        {
            Console.WriteLine(this);
            DisplayAllCages();
            DisplayAllMaintainers();
        }

        public void DisplayAllCages()
        {
            foreach (Cage cage in Cages)
                Console.WriteLine(cage);
        }

        public void DisplayAllMaintainers()
        {
            foreach (Maintainer maintainer in Maintainers)
                Console.WriteLine(maintainer);
        }
    }
}
