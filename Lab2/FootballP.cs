﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class FootballP : Footballer
    {
        public FootballP(string firstName, string secondName, DateTime dayOfBirth,
            string position, string team) :
            base(firstName, secondName, dayOfBirth, position, team)
        { }

        public override void Score()
        {
            Console.WriteLine("Footballer score a goal!");
            base.Score();
        }


    }
}
