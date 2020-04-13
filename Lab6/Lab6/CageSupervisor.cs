using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class CageSupervisor : Employee, IInfo
    {
        public IList<Cage> Cages { get; set; }
        public CageSupervisor(string firstName, string lastName, DateTime birthDate, DateTime employmentDate, IList<Cage> cages )
            : base(firstName, lastName, birthDate, employmentDate)
        {
            Cages = cages;
        }


        public void CleanCages()
        {
            foreach (var item in Cages)
            {
                if (!item.RequiresCleaning)
                {
                    Console.WriteLine($"Cages ID:{item.ID} does not requiere a cleaning\n");
                }
                else
                {
                    Console.WriteLine($"{item} has been cleared\n");
                    item.RequiresCleaning = false;
                }
            }
        }

        public override string ToString()
        {
            string str = base.ToString() + $"Cages:\n";
            foreach (var item in Cages)
            {
                str += item;
            }
            return str;
        }

        public override void Details()
        {
            Console.WriteLine(this);
        }

    }
}
