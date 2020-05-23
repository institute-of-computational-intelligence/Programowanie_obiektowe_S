using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab6
{
    public class Kepeer
    {
        public string Name { get; }
        public string Surname { get; }
        public List<Cage> Cages { get; set; } = new List<Cage>();

        public Kepeer(string name_, string surname_)
        {
            Name = name_;
            Surname = surname_;
        }

        public Kepeer(string name_, string surname_, List<Cage> cages_)
        {
            Name = name_;
            Surname = surname_;
            Cages = cages_;
        }

        public void CleaningCage(int ID)
        {
            foreach (var x in Cages)
            {
                if (x.Number == ID)
                {
                    x.CleanUpNeeded = false;
                    break;
                }
            }
        }

        public void AddCage(Cage cage)
        {
            Cages.Add(cage);
        }

        public override string ToString()
        {
            string info = $"Name: {Name}, Surname: {Surname}, ID's of cages: ";
            foreach (var x in Cages)
            {
                info += $"{x.Number}  ";
            }
            return info;
        }
    }
}