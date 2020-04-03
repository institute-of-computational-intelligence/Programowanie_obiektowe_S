using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class FootballPlayer : Player
    {
        public FootballPlayer() : base() { }
        public FootballPlayer(string firstName, string lastName, DateTime birthDate, string position, string club) : base(firstName, lastName, birthDate, position, club) { }
        public override void ScoreGoal()
        {
            base.ScoreGoal();
            Console.WriteLine("Football player scored a goal!");
        }
    }
}