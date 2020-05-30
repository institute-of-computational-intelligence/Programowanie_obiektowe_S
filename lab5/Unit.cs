using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Unit : IInfo
    {
        public string Name { get; set; }
        public string Adres { get; set; }
        public List<Lectuer> Lectuers { get; set; }

        public Unit(string name, string adres)
        {
            this.Name = name;
            this.Adres = adres;

            Lectuers = new List<Lectuer>();
        }

        public void AddLectuler(Lectuer lec)
        {
            Lectuers.Add(lec);
        }

        public void RemoveLectuler(Lectuer lec)
        {
            Lectuers.Remove(lec);
        }

        public void RemoveLectuler(string name,string surname)
        {

//           foreach (Lectuer le in Lectuers)
//               if (le.Equals(name) && le.Equals(surname))
//                  Lectuers.Remove(le);

            for(int i = 0; i < Lectuers.Count; i++)
                if (Lectuers[i].Name.Equals(name) && Lectuers[i].Name.Equals(surname))
                    Lectuers.RemoveAt(i);
        }

        public override string ToString()
        {
            return $"Name: {Name} Adres: {Adres}";
        }

        public virtual void details()
        {
            Console.WriteLine(this);
        }

        public void InfoLect()
        {
            foreach (Lectuer le in Lectuers)
                Console.WriteLine(le);
        }
    }
}
