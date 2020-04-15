using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Birds : Animal
    {
        public string Type { get; set; }
        public string Food { get; set; }
        public string Origin { get; set; }
        public double Wingspan { get; set; }
        public int Strength { get; set; }
        Cage cage = new Cage();
        public int Flight_length(int wingspan, int strength)
        {
            return wingspan * strength;
        }
        public Birds(string food, int id, string origin,string type, double wingspan, int strength)
        { }
    }
}
