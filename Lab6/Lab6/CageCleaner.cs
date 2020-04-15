using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public class CageCleaner : Worker
    {
        public List<Cage> Cages { get; set; }
        public CageCleaner(string name, string surname, DateTime birth, DateTime dateOfEmployment, List<Cage> cages) 
            : base(name, surname, birth, dateOfEmployment)
        {
            Cages = cages;
        }

        public void Clean()
        {
            foreach (var cage in Cages)
            {
                if(cage.RequiredCleaning)
                {
                    Console.WriteLine($"Cleaned cage {cage.IdentificationNumner}");
                }
            }
        }
    }
}
