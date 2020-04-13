using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Cage : IInfo
    {
        public IList<Animal> Animals { get; set; }
        public int ID { get; set; }
        public bool RequiresCleaning { get; set; }
        public int Capacity { get; set; }

        private static int counter = 0;
        public Cage(int capacity, bool requiresCleaning, IList<Animal> animals)
        {
            Animals = animals ?? throw new ArgumentNullException(nameof(animals));
            RequiresCleaning = requiresCleaning;
            Capacity = capacity;
            ID = ++counter;
        }
        public override string ToString()
        {
            string str = $"Cage ID:{ID}, Capacity:{Capacity}, Cleaning requires:{(RequiresCleaning ? "Yes" : "No")}, Animals in cage:\n";
            foreach (var item in Animals)
            {
                str += item;
            }
            return str;
        }
        public void Details()
        {
            Console.WriteLine(this);
        }
    }
}
