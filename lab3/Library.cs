using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Library : IPositionManagment,ILibrarianManagment
    {
        public string Adres { get; set; }
        private List<Liblarian> liblarians = new List<Liblarian>();
        private List<Catalog> catalogs = new List<Catalog>();

        public Library()
        {
            Adres = "none";
        }

        public Library(string adres)
        {
            Adres = adres;
        }

        public void AddLibrarian(Liblarian a1)
        {
            liblarians.Add(a1);
        }

        public void DeleteLibrarian()
        {
            liblarians.Clear();
        }

        public void ShowLibrarian()
        {
            Console.WriteLine($"Adres: {Adres}");
            foreach(Liblarian a in liblarians)
            {
                Console.WriteLine(a);
            }
        }

        public void AddCatalog(Catalog c1)
        {
            catalogs.Add(c1);
        }

        public void AddPosition(Position p,string tematicLVl)
        {
            foreach(Catalog c in catalogs)
            {
                if(c.tematicLvl == tematicLVl)
                {
                    c.AddPostions(p);
                }
            }
        }

        public Position FindPositionbyTitle(string title)
        {
            foreach(Catalog c in catalogs)
            {
                foreach(Position p in c.positions)
                 {
                     if (p.Title == title)
                         return p;
                 }
            }
            return null;
        }

        public Position FindPositionById(int id)
        {
            foreach (Catalog c in catalogs)
            {
                foreach (Position p in c.positions)
                {
                    if (p.Id == id)
                        return p;
                }
            }
            return null;
        }

        public void ShowAll()
        {
            foreach(Catalog c in catalogs)
            {
                c.ShowAll();
            }
        }

    }
}
