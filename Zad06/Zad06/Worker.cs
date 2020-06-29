using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad06
{
    class Worker
    {
        private string name;
        private List<Cage> workrer_cages = new List<Cage>();

        public Worker()
        {
            name = "--";
        }

        public Worker(string name_)
        {
            name = name_;
        }

        public void AddCage(Cage c)
        {
            workrer_cages.Add(c);
        }

        public override string ToString()
        {
            return $"Worker | Name: {name}";
        }

        public void Details()
        {
            Console.WriteLine(this);
            foreach (Cage c in workrer_cages)
                c.Details();
        }

    }
}
