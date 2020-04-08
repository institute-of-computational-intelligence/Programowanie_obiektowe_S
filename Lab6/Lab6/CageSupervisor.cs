using System;
using System.Collections.Generic;

namespace Lab6
{
	class CageSupervisor : Employee
	{
		public List<Cage> Cages { get; set; }

		public CageSupervisor(string firstname, string lastname, DateTime dateOfBirth, DateTime dateOfEmployment, List<Cage> cages)
			: base(firstname, lastname, dateOfBirth, dateOfEmployment)
		{
			ParamCheck.IsNull(cages);
			Cages = cages;
		}

		public void CleanCages()
		{
			foreach (var cage in Cages)
			{
				if(cage.RequiresCleaning)
				{
					Console.WriteLine($"Cleaned cage {cage.ID}");
				}
			}
		}
	}
}
