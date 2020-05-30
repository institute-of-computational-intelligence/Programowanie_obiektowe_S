using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Author : Person
    {
        public string Nationality { get; set; }

        public Author() : base()
        {
            Nationality = "none";
        }

        public Author(string name_,string lastName_,string national) : base (name_,lastName_)
        {
            Nationality = national;
        }

        public override string ToString()
        {
            return base.ToString()+ $"Nationality: {Nationality}";
        }
    }
}
