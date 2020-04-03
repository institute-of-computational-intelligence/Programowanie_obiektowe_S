using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Player : Person
    {
        private string position;
        private string club;
        private int goalCount = 0;
        public Player()
        {

        }
        public Player(string firstName, string lastName, DateTime birthDate, string _position, string _club) : base(firstName, lastName, birthDate)
        {
            position = _position;
            club = _club;
        }

        public string Position { get => position; set => position = value; }
        public string Club { get => club; set => club = value; }
        public int GoalCount { get => goalCount; set => goalCount = value; }

        public override string ToString()
        {
            return base.ToString() + $"\nPosition: {position}, Club: {club}, Goal count: {goalCount}";
        }
        public override void Details()
        {
            Console.WriteLine(this);
        }
        public virtual void ScoreGoal()
        {
            goalCount++;
        }
    }
}