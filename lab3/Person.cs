using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Person
    {
        protected string name;
        protected string lastName;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public Person()
        {
            name = "unknonw";
            lastName = "unknonw";
        }

        public Person(string nam,string lasnam)
        {
            name = nam;
            lastName = lasnam;
        }

        public override string ToString()
        {
            return $"name: {name}, Last name {lastName}";
        }

    }
}
