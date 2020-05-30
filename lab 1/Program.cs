using System;


namespace lab_1
{
    


    class Samochod
    {
        private static int iloscSamochodow = 0;
        private string marka;
        private string model;
        private int iloscDrzwi;
        private int pojemnoscSilnika;
        private double srednieSpalanie;
        private string numerRejestracyjny;


        public Samochod()
        {
            marka = null;
            model = null;
            iloscDrzwi = 0;
            pojemnoscSilnika = 0;
            srednieSpalanie = 0.0;
            numerRejestracyjny= null;
            iloscSamochodow++;
        }

        public Samochod(string marka_, string model_, int iloscDrzwi_, int pojemnoscSilnika_, double srednieSpalanie_, string numerRejestracyjny_)
        {
            marka = marka_;
            model = model_;
            iloscDrzwi = iloscDrzwi_;
            pojemnoscSilnika = pojemnoscSilnika_;
            srednieSpalanie = srednieSpalanie_;
            numerRejestracyjny = numerRejestracyjny_;
            iloscSamochodow++;
        }

        public string Marka
        {
            get { return marka; }
            set { marka = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int IloscDrzwi
        {
            get { return iloscDrzwi; }
            set { iloscDrzwi = value; }
        }
        public int PojemnoscSilnika
        {
            get { return pojemnoscSilnika; }
            set { pojemnoscSilnika = value; }
        }
        public double SrednieSpalanie
        {
            get { return srednieSpalanie; }
            set { srednieSpalanie = value; }
        }
        public int IloscSamochodow
        {
            get { return iloscSamochodow; }
            set { iloscSamochodow = value; }
        }
        public string NumerRejestracyjny
        {
            get { return numerRejestracyjny; }
            set { numerRejestracyjny = value; }
        }

        private double Obliczspalanie(double dlugoscTrasy)
        {
            return (srednieSpalanie * dlugoscTrasy) / 100;
        }

        public double ObliczKosztPrzejazdu(double dlugoscTrasy,double cenaPaliwa)
        {
            return Obliczspalanie(dlugoscTrasy)*cenaPaliwa;
        }

        public void WypiszInfo()
        {
            Console.WriteLine("Marka: " + marka);
            Console.WriteLine("Model: " + model);
            Console.WriteLine("Ilosc Drzwi: " +iloscDrzwi );
            Console.WriteLine("Pojemnosc Silnika: " + pojemnoscSilnika);
            Console.WriteLine("Srednie spalanie: " + srednieSpalanie);
            Console.WriteLine("Liczba samochodow: " + iloscSamochodow);
            Console.WriteLine("Numer rejestracyjny: " + numerRejestracyjny);

        }

        public static void WypiszIloscSamochodow()
        {
            Console.WriteLine(iloscSamochodow);
        }
    }

    class Garaz
    {
        private string adres;
        private int pojemnosc;
        private int liczbaSamochodow = 0;
        private Samochod[] samochody;

        public Garaz()
        {
            adres = "nieznany";
            pojemnosc = 0;
            samochody = null;
        }

        public Garaz(string adres_,int pojemnosc_)
        {
            adres = adres_;
            pojemnosc = pojemnosc_;
            samochody = new Samochod[pojemnosc];
        }

        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }

        public int Pojemnosc
        {
            get { return pojemnosc; }
            set 
            { 
                pojemnosc = value;
                samochody = new Samochod[pojemnosc];
            }
        }


        public void WprowadzSamochod(Samochod a1)
        {
            if (liczbaSamochodow == pojemnosc) { Console.WriteLine("Pelen garaz"); }
            else
            {
                samochody[liczbaSamochodow] = a1;
                liczbaSamochodow++;
            }
        }

        public void WyprowadzSamochod()
        {
            if (liczbaSamochodow == 0) { Console.WriteLine("Pusty garaz"); }
            else
            {
                samochody[liczbaSamochodow-1] = null;
                liczbaSamochodow--;
            }
        }

        public void Wypiszinfo()
        {
            Console.WriteLine("Adres: " + adres);
            Console.WriteLine("Pojemnosc: " + pojemnosc);
            Console.WriteLine("Liczba samochodow: " + liczbaSamochodow +"\n");
            for (int i = 0; i < liczbaSamochodow; i++)
            {
                samochody[i].WypiszInfo();
            }
        }
    }

    class Osoba
    {
        private string imie;
        private string nazwisko;
        private string adresZamieszkania;
        private int iloscSamochodow = 0;
        private Samochod[] samochody;

        public Osoba()
        {
            imie = null;
            nazwisko = null;
            adresZamieszkania = null;
            samochody = null;
        }

        public Osoba(string a1, string a2, string a3,int a4)
        {
            imie = a1;
            nazwisko = a2;
            adresZamieszkania = a3;
            iloscSamochodow = a4;
            if (iloscSamochodow < 3)
                samochody = new Samochod[3];
            else
                Console.WriteLine("osoba nie moze miec tyle aut max 3"); 
        }

        public void Dodajsamochod(string nrRekestracyjny)
        {
            if (iloscSamochodow < 3)
            {
                samochody[iloscSamochodow].NumerRejestracyjny = nrRekestracyjny;
                iloscSamochodow++;
            }
            else
                Console.WriteLine("osoba nie moze miec tyle aut max 3");        
        }

        public void UsunSamochod(string nrRekestracyjny)
        {
            for(int i = 0; i < iloscSamochodow; i++)
            {
                if (samochody[i].NumerRejestracyjny == nrRekestracyjny)
                {
                    samochody[i] = samochody[2];
                    samochody[2] = null;
                }
                 

            }
            iloscSamochodow--;
        }


        public void WypiszInfo()
        {
            Console.WriteLine("imie: " + imie);
            Console.WriteLine("nazwisko: " + nazwisko);
            Console.WriteLine("adres zam: " + adresZamieszkania);
            for(int i = 0; i < iloscSamochodow; i++)
            {
                Console.WriteLine(samochody[i].NumerRejestracyjny);
                Console.WriteLine("\n");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Samochod s1 = new Samochod("Fiat", "126p", 2, 650, 6.0,"K1 DIS");
            Samochod s2 = new Samochod("Syrena", "105", 2, 800, 7.6,"K1 FRIZ");
            Garaz g1 = new Garaz();
            g1.Adres = "ul. Garaiowa 1";
            g1.Pojemnosc = 1;
            Garaz g2 = new Garaz("ul. Garaiowa 2", 2);
            g1.WprowadzSamochod(s1);
            g1.Wypiszinfo();
            g1.WprowadzSamochod(s2);
            Console.WriteLine("=================");
            g2.WprowadzSamochod(s2);
            g2.WprowadzSamochod(s1);
            g2.Wypiszinfo();
            g2.WyprowadzSamochod();
            g2.Wypiszinfo();
            g2.WyprowadzSamochod();
            g2.WyprowadzSamochod();

            Console.WriteLine("=================");

/*
            Osoba o1 = new Osoba("Norber", "Gierczak", "Krakow", 0);
            Osoba o2 = new Osoba("asdfa", "asd", "asd", 0);

            o1.Dodajsamochod(s1);

            o1.WypiszInfo();
*/


            Console.ReadKey();

        }
    }
}
