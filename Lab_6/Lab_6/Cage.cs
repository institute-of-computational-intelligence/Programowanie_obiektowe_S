using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_6
{
    public class Cage
    {
        public int ID { get;  }
        public int Capacity { get; set; }
        public bool RequiresCleaning { get;  }
        public List<Animal> Animals { get;  }
        private static int instanceCount = 0;

        public Cage(int capacity,bool requiesCleaning, List<Animal> animals)
        {
            instanceCount++;
            ID = instanceCount;
            Capacity = capacity;
            RequiresCleaning = requiesCleaning;
            Animals = animals;
        }
    }
}
