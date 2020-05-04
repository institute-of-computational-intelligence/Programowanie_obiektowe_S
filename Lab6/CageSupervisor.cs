using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class CageSupervisor: Employee, IAction
    {
        private IList<Cage> cages = new List<Cage>();

        public CageSupervisor()
        {
        }
        public CageSupervisor(string name, string surname, DateTime born, DateTime hired, IList<Cage> cages) :base(name, surname, born, hired)
        {
            this.cages = cages;
        }

        public IList<Cage> Cages { get => cages; }

        public void CleanCage(Cage cage)
        {
            if (!Cages.Contains(cage)) throw new Exception("Cage is not assigned to this supervisor.");
            cage.Dirty = false;
        }

        public void CleanCages()
        {
            foreach (Cage c in cages)
                c.Dirty = false;
        }

        public override string ToString()
        {
            return $"Dozorca: {base.Name} {base.Surname} ur.{base.Born} zatrudniony: {base.Hired}";
        }
    }
}
