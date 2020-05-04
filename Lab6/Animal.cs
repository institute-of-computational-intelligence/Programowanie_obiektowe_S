using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public abstract class Animal: IInfo
    {
        private string species;
        private int food;
        private string origin;
        private string suborder;

        public Animal()
        {
        }

        protected Animal(string species, int food, string origin, string suborder)
        {
            this.suborder = suborder;
            this.species = species;
            this.food = food;
            this.origin = origin;
        }

        protected string Species { get => species; set => species = value; }
        public int Food { get => food; set => food = value; }
        public string Origin { get => origin; set => origin = value; }
        public string Suborder { get => suborder; set => suborder = value; }

        public override string ToString()
        {
            return $"Zwierze: {species}, podrzad: {suborder} rodz. pozywienia: {food}";
        }

        public virtual void DisplayInfo()
        {
            throw new NotImplementedException();
        }
    }
}
