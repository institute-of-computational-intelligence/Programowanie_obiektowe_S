using System;

namespace Lab6.BLL
{
    public class Bird : Animal
    {
        protected double _wingsSpread;

        public double WingsSpread
        {
            get { return _wingsSpread; }
            set { _wingsSpread = value; }
        }
        protected int _stammina;

        public int Stammina
        {
            get { return _stammina; }
            set { _stammina = value; }
        }

        public double MaxFlightDistance => _wingsSpread * _stammina;

        public Bird(string foodType, int legsCount, string origin, string species, double wingsSpread, int stammina)
            : base(foodType, legsCount, origin, species)
        {
            _wingsSpread = wingsSpread;
            _stammina = stammina;
        }
        public override string ToString()
        {
            return base.ToString()+ $", Wings spread: {_wingsSpread}, Stammina: {_stammina}, MaxFlightDistance: {MaxFlightDistance}";
        }

        public void Fly()
        {
            Console.WriteLine("Bird is flying...");
        }



    }
}
