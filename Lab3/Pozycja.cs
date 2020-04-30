using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    abstract class Pozycja
    {
        protected string tytul;
        protected int id;
        protected string wydawnictwo;
        protected int rokWydania;

        public Pozycja() 
        {
            tytul = "Brak tytulu";
            id = 0;
            wydawnictwo = "Brak wydawnictwa";
            rokWydania = 0;
        }

        public Pozycja(string tytul_, int id_, string wydawnictwo_, int rokWydania_)
        {
            tytul = tytul_;
            id = id_;
            wydawnictwo = wydawnictwo_;
            rokWydania = rokWydania_;
        }

        public string Tytul
        {
            get { return tytul; }
        }

        public int Id
        {
            get { return id; }
        }

        public abstract void WypiszInfo();
    }
}
