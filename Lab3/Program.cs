using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Katalog literatura = new Katalog("literatura");
            Pozycja ksiazka1 = new Ksiazka("ksiazka1", 1, "wydawnictwo1", 1990, 300);
            Pozycja ksiazka2 = new Ksiazka("ksiazka2", 3, "wydawnictwo1", 1992, 325);
            Pozycja ksiazka3 = new Ksiazka("ksiazka3", 4, "wydawnictwo2", 2002, 225);
            Pozycja czasopismo1 = new Czasopismo("czasopismo1", 2, "wydawnictwo2", 2001, 2);
            Pozycja czasopismo2 = new Czasopismo("czasopismo2", 5, "wydawnictwo1", 1992, 325);
            literatura.DodajPozycje(ksiazka1);
            literatura.DodajPozycje(czasopismo1);
            literatura.DodajPozycje(new Ksiazka());
            literatura.DodajPozycje(new Czasopismo());
            literatura.DodajPozycje(ksiazka2);
            literatura.DodajPozycje(ksiazka3);
            literatura.DodajPozycje(czasopismo2);

            literatura.WypiszWszystkiePozycje();
            Console.WriteLine("\n");

            literatura.ZnajdzPozycjePoTytule("ksiazka1").WypiszInfo();
            ((Ksiazka)literatura.ZnajdzPozycjePoTytule("ksiazka3")).DodajAutora(new Autor("Jan", "Dluzny"));
            literatura.WypiszWszystkiePozycje();

            Console.ReadKey();
        }
    }
}
