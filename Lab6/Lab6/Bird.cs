using System;

namespace Lab6
{
	class Bird : Animal
	{
		public int Endurance { get; set; }
		public double Wingspan { get; set; }

		public Bird(string species, string food, string origin, double wingspan, int endurance) 
			: base(species, food, origin)
		{
			Wingspan = wingspan;
			Endurance = endurance;
		}

		public void Fly()
		{
			Console.WriteLine($"{Species} flew {Wingspan * Endurance} thanks to his wingspan of {Wingspan} and {Endurance} endurance");
		}
	}
}
