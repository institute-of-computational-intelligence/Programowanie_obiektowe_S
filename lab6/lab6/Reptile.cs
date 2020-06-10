using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    class Reptile : Animal
    {
        bool poison;

        public Reptile()
        {
            poison = false;
        }

        public Reptile(string species_, string food_, string orgin_, bool poison_) :
            base (species_, food_, orgin_)
        {
            poison = poison_;
        }

        public override string ToString()
        {
            return base.ToString() + $"Type: Reptile\r\n\tPoisonous: {poison}";
        }

        public override void Details()
        {
            Console.WriteLine(this);
        }
    }
}
