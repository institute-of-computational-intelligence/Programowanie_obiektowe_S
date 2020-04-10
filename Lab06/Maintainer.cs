using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06
{
    class Maintainer : Person
    {
        public IList<Cage> MaintainedCages { get; }

        public Maintainer(string name, string surname) : base(name, surname)
        {
            MaintainedCages = new List<Cage>();
        }

        public Maintainer(string name, string surname, IList<Cage> maintainedCages) : base(name, surname)
        {
            MaintainedCages = maintainedCages;
        }

        public void CleanUpCage(int cageID)
        {
            foreach (Cage cage in MaintainedCages)
                if (cageID == cage.Identificator)
                {
                    if (cage.IsClean) Console.WriteLine($"{cage} does not require cleaning!");
                    else
                    {
                        Console.WriteLine($"{base.ToString()} tidied up cage {cage}");
                        cage.IsClean = true;
                    }
                }
        }

        public override string ToString()
        {
            string baseStr = base.ToString() + ", maintains cages:\r\n";

            foreach (Cage cage in MaintainedCages)
            {
                baseStr += cage + "\r\n";
            }

            return baseStr;
        }

        public new void DisplayInfo()
        {
            Console.WriteLine(this);
        }
    }
}
