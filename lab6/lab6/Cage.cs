using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Cage
    {
        public int Capacity { get; set; }
        public int Id { get; set; }

        public bool Dirty { get; set; }
        public IList<Animal> Animals { get; set; }
        public Cage(int id, bool dirty, IList<Animal> animals)
        {

        }

        public Cage()
        {
        }

        public void Display()
        {}
    }
}
