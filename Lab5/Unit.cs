using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Unit : IInfo
    {
        private string name, address;
        List<Lector> lectors = new List<Lector>();

        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        internal List<Lector> Lectors { get => lectors; set => lectors = value; }

        public Unit(string name, string address)
        {
            this.name = name;
            this.address = address;
        }

        public Unit()
        {
        }

        public void Details()
        {
            Console.WriteLine(this);
        }

        public void AddLector(Lector l)
        {
            lectors.Add(l);
        }

        public void LectorsDetails()
        {
            Console.WriteLine(String.Join("\r\n", lectors));
        }

        public override string ToString()
        {
            return $"{name} {address} ";
        }
    }
}
