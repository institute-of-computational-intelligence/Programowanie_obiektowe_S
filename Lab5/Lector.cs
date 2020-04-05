using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Lector:Person
    {
        private string scDegree;

        public Lector(string name, string surname, string born, string scDegree) : base(name, surname, born)
        {
            this.scDegree = scDegree;
        }

        public override void Details()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return base.ToString() + $" tytul nauk: {scDegree}";
        }

    }
}
