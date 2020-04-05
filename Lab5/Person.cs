using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Person:IInfo
    {
        private string name;
        private string surname;
        private string born;

        protected string Name { get => name; set => name = value; }
        protected string Surname { get => surname; set => surname = value; }
        protected string Born { get => born; set => born = value; }

        public Person(string name, string surname, string born)
        {
            this.name = name;
            this.surname = surname;
            this.born = born;
        }

        public Person()
        {
        }

        public virtual void Details()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return $"{name} {surname} {born}";
        }
    }
}
