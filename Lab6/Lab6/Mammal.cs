namespace Lab6
{
	class Mammal : Animal
	{
		public string NaturalHabitat { get; set; }

		public Mammal(string species, string food, string origin, string naturalHabitat)
			: base(species, food, origin)
		{
			ParamCheck.IsNullOrWhitespace(naturalHabitat);

			NaturalHabitat = naturalHabitat;
		}
	}
}
