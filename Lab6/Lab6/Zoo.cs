using Lab6.Interfaces;
using System;
using System.Collections.Generic;

namespace Lab6
{
	class Zoo : IAction
	{
		public string Name;
		public List<Cage> Cages;
		public List<Employee> Employees;

		public Zoo(string name)
		{
			ParamCheck.IsNullOrWhitespace(name);

			Name = name;
			Cages = new List<Cage>();
			Employees = new List<Employee>();
		}

		public Cage BuildCage(int capacity, bool requiresCleaning)
		{
			return new Cage(capacity, requiresCleaning, new List<Animal>());
		}

		public void ExpandCage(Cage cage, int newCapactiy)
		{
			cage.Capacity = newCapactiy;
		}

		public Employee HireEmployee(string firstname, string lastname, DateTime dateOfBirth)
		{
			return new Employee(firstname, lastname, dateOfBirth, DateTime.UtcNow);
		}

		public void AddAnimal(Cage cage, Animal animal)
		{
			cage.Animals.Add(animal);
		}

		public void DisplayAllCages()
		{
			// prawdopodobnie skorzystam z method extentions
		}
	}
}
