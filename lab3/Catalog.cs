using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Catalog : IPositionManagment
    {
        public string tematicLvl { get; set; }
        public List<Position> positions = new List<Position>();

        public Catalog()
        {
            tematicLvl = "unknown";
        }

        public Catalog(string tematicLvl_)
        {
            tematicLvl = tematicLvl_;
        }

        public void AddPostions(Position p1)
        {
            positions.Add(p1);
        }

        public Position FindPositionbyTitle(string title)
        {
            foreach(Position p in positions)
            {
                if (p.Title == title)
                    return p;
            }
            return null;
        }

        public Position FindPositionById(int id)
        {
            foreach (Position p in positions)
            {
                if (p.Id == id)
                    return p;
            }
            return null;
        }

        public void ShowAll()
        {
            Console.WriteLine($"TematicLVL: {tematicLvl}");
            foreach(Position p in positions)
            {
                p.Details();
            }
        }

        public override string ToString()
        {
            return $"tematic Lvl: {tematicLvl}";
        }
    }
}
