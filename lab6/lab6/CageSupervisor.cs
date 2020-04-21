using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab6
{
    public class CageSupervisor : Employee
    {
        public IList<Cage> Cages { get; set; }
        public CageSupervisor(string firstName, string lastName, DateTime hireDate, DateTime dismissDate, List<Cage> cages):
            base (firstName, lastName, hireDate, dismissDate)
        {
            Cages = cages;
        }
    }
}