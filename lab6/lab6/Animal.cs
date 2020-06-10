using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    class Animal
    {
        protected string species;
        protected string food;
        protected string orgin;

        public Animal()
        {
            species = "--";
            food = "--";
            orgin = "--";
        }

        public Animal(string species_, string food_, string orgin_)
        {
            species = species_;
            food = food_;
            orgin = orgin_;
        }

        public override string ToString()
        {
            return $"Animal| Species: {species}, food: {food}, orgin: {orgin}";
        }

        public virtual void Details()
        {
            Console.WriteLine(this);
        }
    }
}
