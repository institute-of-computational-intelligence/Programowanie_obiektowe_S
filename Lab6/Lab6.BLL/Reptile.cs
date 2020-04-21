namespace Lab6.BLL
{
    /// <summary>
    /// Gad
    /// </summary>
    public class Reptile : Animal
    {
        protected bool IsVenomous { get; set; }

        public Reptile(string foodType, int legsCount, string origin, string species, bool isVenomous)
            : base(foodType, legsCount, origin, species)
        {
            IsVenomous = isVenomous;
        }
        public override string ToString()
        {
            return base.ToString() + $", Is Venomous: {IsVenomous}";
        }
    }
}
