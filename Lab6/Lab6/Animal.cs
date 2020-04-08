using Lab6.Interfaces;
using System;

namespace Lab6
{
	class Animal : IInfo
	{
		public string Species { get; set; }
		public string FeedsOn { get; set; }
		public string Origin { get; set; }

		public Animal(string species, string food, string origin)
		{
			ParamCheck.IsNullOrWhitespace(species);
			ParamCheck.IsNullOrWhitespace(food);
			ParamCheck.IsNullOrWhitespace(origin);

			Species = species;
			FeedsOn = food;
			Origin = origin;
		}

		public void Display()
		{
			Console.WriteLine($"Species: {Species} Feeds on: {FeedsOn} Origin: {Origin}");
		}
	}
}
