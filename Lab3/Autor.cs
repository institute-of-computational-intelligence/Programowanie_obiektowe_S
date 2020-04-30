using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Autor
    {
        private string imie;
        private string nazwisko;

        public Autor()
        {
            imie = "Brak imienia";
            nazwisko = "Brak nazwiska";
        }

        public Autor(string imie_, string nazwisko_)
        {
            imie = imie_;
            nazwisko = nazwisko_;
        }

        public void WypiszInfo()
        {
            Console.Write("{0}\t{1}\t", imie, nazwisko);
        }
    }
}
