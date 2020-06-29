using System;
using System.Collections.Generic;
using System.Text;

namespace Zad03 {
    class Catalog : IPositionsManagement {
        private string sectionTheme;
        private List<Position> positions = new List<Position>();
        public string SectionTheme { get => sectionTheme; set => sectionTheme = value; }

        public Catalog() {
            sectionTheme = "null";
        }
        public Catalog(string sectionTheme) {
            this.sectionTheme = sectionTheme;
        }
        public void AddPosition(Position p) {
            positions.Add(p);
        }
        public Position FindPositionByTitle(string title) {
            foreach (Position p in positions) {
                if (title == p.Title) { return p; }
            }
            return null;
        }
        public Position FindPositionById(int id) {
            foreach (Position p in positions) {
                if (id == p.Id) { return p; }
            }
            return null;
        }
        public override string ToString() {
            return $"Section Theme: {sectionTheme}";
        }
        public void PoisitonsDetails() {
            Console.WriteLine(this);
            foreach (Position p in positions) {
                p.Details();
            }
        }
    } 
}
