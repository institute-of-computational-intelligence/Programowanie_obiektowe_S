
using System;
using Generic.Extensions;

namespace Lab6.BLL
{
    public abstract class Animal : IMovingMethod, IInfo
    {
        protected string _species;

        public string Species
        {
            get { return _species; }
            set { _species = value; }
        }
        protected string _foodType;

        public string FoodType
        {
            get { return _foodType; }
            set { _foodType = value; }
        }
        protected string _origin;

        public string Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }
        protected int _legsCount;

        public int LegsCount
        {
            get { return _legsCount; }
            set { _legsCount = value; }
        }

        public override string ToString()
        {
            return $"Animal species: {_species}, Food type{_foodType}, Origin: {_origin}, Legs count:{_legsCount}";
        }

        public virtual void Display()
        {
            Console.WriteLine(this);
        }

        public Animal(string foodType, int legsCount, string origin, string species)
        {
            _legsCount = legsCount;
            _foodType = foodType;
            _origin = origin;
            _species = species;
        }
    }
}
