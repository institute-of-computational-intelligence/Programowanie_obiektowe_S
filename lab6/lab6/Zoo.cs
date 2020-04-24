using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Zoo
    {
        public string Name { get; set; }
        public IList<Animal> Animals { get; set; }
        public Zoo(string name)
        {
            Name = name;
        }

        public void Print()
        {

        }
        public void DisplayAllCages()
        { }

            public void AddRange(IList<Animal> animals)
            {

            }
        internal object Set<T1, T2>()
        {
            throw new NotImplementedException();
        }
        public Cage BuildCage(int id, bool dirty)
        { } 

        public void HireEmployee(string name, string firstname, DateTime date)
        { }
        public void ExpandCage(Cage cage,int nr)
        {

        }
    }
}
