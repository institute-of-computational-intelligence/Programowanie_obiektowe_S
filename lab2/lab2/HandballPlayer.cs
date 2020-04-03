using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class HandballPlayer : Player
    {
        public HandballPlayer() : base() { }
        public HandballPlayer(string firstName, string lastName, DateTime birthDate, string position, string club) : base(firstName, lastName, birthDate, position, club) { }
        public override void ScoreGoal()
        {
            base.ScoreGoal();
            Console.WriteLine("Handball player scored a goal!");
        }
    }
}