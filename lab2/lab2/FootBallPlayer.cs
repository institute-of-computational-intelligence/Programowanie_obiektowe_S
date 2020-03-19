﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class FootballPlayer: Player
    {
        public FootballPlayer(string firstName, string lastName, string birthDate, string position, string club):
            base(firstName, lastName, birthDate, position, club)
        {
            GoalCount = 0;
        }

        public override void ScoreGoal()
        {
            base.ScoreGoal();
            Console.WriteLine("Nożny strzelił!");
        }
    }
}
