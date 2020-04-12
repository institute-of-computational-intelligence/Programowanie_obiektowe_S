using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_6
{
    public class CageSupervisor : Employee
    {
        public List<Cage> Cages { get;  }
        public CageSupervisor(string firstname,string lastname,DateTime dateOfBirth, DateTime dateOfEmployment, List<Cage> cages):
            base(firstname,lastname,dateOfBirth,dateOfEmployment)
        {
            Cages = cages;
        }

        public void CleanCages()
        {
            foreach (var cage in Cages)
            {
                if(cage.RequiresCleaning)
                {
                    Console.WriteLine($"Klatka o numerze {cage.ID} została wyczyszczona");
                }
            }
        }
    }
}
