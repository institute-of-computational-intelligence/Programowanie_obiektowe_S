using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab6
{
    public class Animal
    {
        public string Species { get; set; }
        public string Food { get; set; }
        public string Origin { get; set; }

        public Animal(string species, string food, string origin)
        {
            Species = species;
            Food = food;
            Origin = origin;
        }

        public void Display()
        {
            Console.WriteLine($"Species: {Species}, Food: {Food}, Origin: {Origin} ");
        }
    }
}
