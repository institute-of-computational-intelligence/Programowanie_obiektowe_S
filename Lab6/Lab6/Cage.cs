using Lab6.Interfaces;
using System;
using System.Collections.Generic;

namespace Lab6
{
	class Cage : IInfo
	{
		public int ID { get; private set; }
		public int Capacity { get; set; }
		public bool RequiresCleaning { get; set; }
		public List<Animal> Animals { get; set; }
		private static int instanceCount = 0;

		public Cage(int capacity, bool requiresCleaning, List<Animal> animals)
		{
			ParamCheck.IsNull(animals);
			instanceCount++;

			ID = instanceCount;
			Capacity = capacity;
			RequiresCleaning = requiresCleaning;
			Animals = animals;
		}

		public void Display()
		{
			Console.WriteLine($"ID: {ID} Capacity: {Capacity}" +
				$"Requires cleaning: {(RequiresCleaning ? "yes" : "no")}");
			Console.WriteLine("Animals in  this cage:");

			Animals.ForEach(animal => animal.Display());
		}
	}
}
