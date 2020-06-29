using System;
using System.Collections.Generic;
using System.Text;

namespace Zad03 {
    class Library : IPositionsManagement, ILibrariansManagement {
        private string address;
        private List<Librarian> librarians = new List<Librarian>();
        private List<Catalog> catalogs = new List<Catalog>();
        public Library() {
            address = "null";
        }
        public Library(string address) {
            this.address = address;
        }
        public string Address { get => address; set => address = value; }
        public void AddLibrarian(Librarian l) {
            librarians.Add(l);
        }
        public void RemoveLibrarian(Librarian l) {
            if (librarians.Remove(l) == false) { Console.WriteLine("There is no librarian with that details"); }
            else { librarians.Remove(l); }
        }
        public void LibrariansDetails() {
            Console.WriteLine($"Librarians working in library at {address}: ");
            foreach (Librarian l in librarians) {
                Console.WriteLine(l);
            }
        }
        public void AddCatalog(Catalog c) {
            catalogs.Add(c);
        }
        public void AddPosition(Position p, string sectionTheme) {
            foreach (Catalog c in catalogs) {
                if (sectionTheme == c.SectionTheme) {
                    c.AddPosition(p);
                }
            }
        }
        public Position FindPositionByTitle(string title) {
            foreach (Catalog c in catalogs) { 
                if (c.FindPositionByTitle(title) != null) { return c.FindPositionByTitle(title); }
            }
            return null;
        }
        public Position FindPositionById(int id) {
            foreach (Catalog c in catalogs) { 
                if (c.FindPositionById(id) != null) { return c.FindPositionById(id); }
            }
            return null;
        }
        public void PoisitonsDetails() {
            foreach (Catalog c in catalogs) {
                c.PoisitonsDetails();
            } 
        }
    }
}
