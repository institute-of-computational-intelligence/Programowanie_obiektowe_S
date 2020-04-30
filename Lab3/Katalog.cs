using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Katalog
    {
        private string dzialTematyczny;
        private List<Pozycja> listaPozycji;

        public Katalog()
        {
            dzialTematyczny = "Brak dzialu tematycznego";
            listaPozycji = new List<Pozycja>();
        }

        public Katalog(string dzialTematyczny_)
        {
            dzialTematyczny = dzialTematyczny_;
            listaPozycji = new List<Pozycja>();
        }

        public void DodajPozycje(Pozycja pozycja)
        {
            listaPozycji.Add(pozycja);
        }

        public void WypiszWszystkiePozycje()
        {
            foreach (Pozycja pozycja in listaPozycji) 
                pozycja.WypiszInfo();
        }

        public Pozycja ZnajdzPozycjePoTytule(string szukanyTytul)
        {
            foreach (Pozycja pozycja in listaPozycji)
                if (pozycja.Tytul.Equals(szukanyTytul))
                    return pozycja;
            return null;
        }

        public Pozycja ZnajdzPozycjePoId(int szukaneId)
        {
            foreach (Pozycja pozycja in listaPozycji)
                if (pozycja.Id == szukaneId)
                    return pozycja;
            return null;
        }

        public string DzialTematyczny 
        {
            get { return dzialTematyczny; }
            set { dzialTematyczny = value; }
        }
    }
}
