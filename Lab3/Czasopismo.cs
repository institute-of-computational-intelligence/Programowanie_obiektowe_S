using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Czasopismo : Pozycja
    {
        private int numer;

        public Czasopismo() : base()
        {
            numer = 0;
        }

        public Czasopismo(string tytul_, int id_, string wydawnictwo_, int rokWydania_, int numer_)
            : base(tytul_, id_, wydawnictwo_, rokWydania_)
        {
            numer = numer_;
        }

        public override void WypiszInfo()
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", tytul, wydawnictwo, rokWydania, numer, id);
        }
    }
}
