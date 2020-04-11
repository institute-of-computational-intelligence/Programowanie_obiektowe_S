using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class CageSupervisor: Employee
    {
        private List<Cage> cages;

        public CageSupervisor()
        {
            cages = new List<Cage>();
        }
        public CageSupervisor(string name, string surname, DateTime born, DateTime hired, List<Cage> cages) :base(name, surname, born, hired)
        {
            this.cages = cages;
        }

    }
}
