using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_lab
{
    class Footballer: Person
    {
        private string position;
        private string club;
        private int goalCount = 0;

        public Footballer(string name_, string surname_, string birthDate_, string position_, string club_) :
            base(name_, surname_, birthDate_)
        {
            position = position_;
            club = club_;
        }

        public override void WriteInfo()
        {
            Console.WriteLine($"Imie {name}, nazwisko {surname}, data urodzenia {birthDate}");
            Console.WriteLine($"Pozycja {position}, klub {club}, liczba goli {goalCount}\n");
        }

        public void ScoreGoal()
        {
            goalCount += 1;
        }
    }
}
