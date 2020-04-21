namespace Lab6.BLL
{
    /// <summary>
    /// SSak
    /// </summary>
    public class Mammal : Animal
    {
        protected string _naturalEnviroment;

        public Mammal(string foodType, int legsCount, string origin, string species, string naturalEnviroment) 
            : base(foodType, legsCount, origin, species)
        {
            _naturalEnviroment = naturalEnviroment;
        }

        public string NaturalEnviroment
        {
            get { return _naturalEnviroment; }
            set { _naturalEnviroment = value; }
        }
        
        public override string ToString()
        {
            return base.ToString() + $", Natural Enviroment: {_naturalEnviroment}";
        }

        

    }
}
