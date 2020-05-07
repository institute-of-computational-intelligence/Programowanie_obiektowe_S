﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Person : IInfo
    {
        public Person(string name, string surname, DateTime birthday)
        {
            Utilities.CheckNullOrWhitespace(name);
            Utilities.CheckNullOrWhitespace(surname);
            
            if ((DateTime.UtcNow - birthday).Days < 0 || (birthday.Year - DateTime.UtcNow.Year) > 116)
            {
                throw new ArgumentException($"Invalid birthday date. Argument {nameof(birthday)} was either set in future or older than 116.");
            }

            Name = name;
            Surname = surname;
            Birthday = birthday;
        }

        public string Name { get; private set; } 
        public string Surname { get; private set; }
        public DateTime  Birthday { get; private set; }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"{Name} {Surname} {Birthday.ToShortDateString()}");
        }
    }
}