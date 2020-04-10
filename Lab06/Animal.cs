﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06
{
    public abstract class Animal : IInfo
    {
        protected string species;
        protected string typeOfFood;
        protected string origin;

        protected Animal(string species, string typeOfFood, string origin)
        {
            Species = species;
            TypeOfFood = typeOfFood;
            Origin = origin;
        }

        public string Species { get => species; set => species = value; }
        public string TypeOfFood { get => typeOfFood; set => typeOfFood = value; }
        public string Origin { get => origin; set => origin = value; }

        public override string ToString()
        {
            return $"Animal species: {species}, type of food {TypeOfFood}, origin {origin}";
        }

        public abstract void DisplayInfo();
    }
}
