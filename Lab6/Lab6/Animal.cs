using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public abstract class Animal : IInfo, IAction
    {
        public string Origin { get; set; }
        public string FoodType { get; set; }
        public string Species { get; set; }

        public Animal(string foodType, string origin, string species)
        {
            Origin = origin;
            FoodType = foodType;
            Species = species;
        }


        public override string ToString()
        {
            return $"Species:{Species}, Type of food:{FoodType}, Origin:{Origin}\n";
        }
        public abstract void Details();
    }
}
