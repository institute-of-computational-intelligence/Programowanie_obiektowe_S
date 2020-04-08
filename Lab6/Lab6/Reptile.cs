namespace Lab6
{
	class Reptile : Animal
	{
		public bool IsVenomous { get; set; }

		public Reptile(string species, string food, string origin, bool isVenomous) 
			: base(species, food, origin)
		{
			IsVenomous = isVenomous;
		}
	}
}
