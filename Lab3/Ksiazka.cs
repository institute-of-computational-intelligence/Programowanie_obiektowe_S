using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Ksiazka : Pozycja
    {
        private int liczbaStron;
        private List<Autor> autorzy;

        public Ksiazka() : base()
        {
            liczbaStron = 0;
            autorzy = new List<Autor>();
        }

        public Ksiazka(string tytul_, int id_, string wydawnictwo_, int rokWydania_, int liczbaStron_)
            : base(tytul_, id_, wydawnictwo_, rokWydania_)
        {
            liczbaStron = liczbaStron_;
            autorzy = new List<Autor>();
        }
        
        public void DodajAutora(Autor autor)
        {
            autorzy.Add(autor);
        }

        public override void WypiszInfo()
        {
            Console.Write("{0}\t{1}\t{2}\t{3}\t{4}\t", tytul, wydawnictwo, rokWydania, liczbaStron, id);
            foreach (Autor autor in autorzy)
                autor.WypiszInfo();
            Console.WriteLine();
        }
    }
}
