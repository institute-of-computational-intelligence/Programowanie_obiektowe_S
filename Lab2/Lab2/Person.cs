﻿using System;

namespace Lab2
{
    public class Person
    {
        protected string Name { get; set; }
        protected string Surname { get; set; }
        protected DateTime Birthday { get; set; } // change to DateTime

        public Person(string name, string surname, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
        }

        public void PrintInfo()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return $"Name: {Name} Surname: {Surname} Birthday: {Birthday.ToShortDateString()}\n";
        }
    }
}