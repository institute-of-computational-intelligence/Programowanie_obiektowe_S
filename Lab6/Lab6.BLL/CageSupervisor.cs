using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Extensions;

namespace Lab6.BLL
{
    public class CageSupervisor : Employee, IAction
    {
        public IList<Cage> Cages { get; private set; }

        public CageSupervisor(string firstName, string lastName, DateTime dateOfBirth, DateTime hireDate,
            IList<Cage> cages)
            : base(firstName, lastName, dateOfBirth, hireDate)
        {
            Cages = cages;
        }
        
        public override string ToString()
        {
            var str = base.ToString() + "\r\n Cages \r\n";
            str += string.Join("\r\n", Cages.Select(cage => cage.ToString()));
            return str;
        }

        public void CleanCage(Cage cage)
        {
            if (!Cages.Contains(cage)) throw new Exception("Cage is not assigned to this supervisor.");
            cage.RequireCleaning = false;
        }

        public void CleanAllCages()
        {
            foreach (var cage in Cages)
                CleanCage(cage);
        }
    }
}