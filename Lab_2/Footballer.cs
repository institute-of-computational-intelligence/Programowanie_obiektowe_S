﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public class Footballer : Person
    {
        public string Position { get; set; }

        public string Club { get; set; }

        public int GoalCount { get; set; }

        public Footballer(string name,string surname,string birthday,string position,string club):
            base(name,surname,birthday)
        {
            Position = position;
            Club = club;
            GoalCount = 0;
        }

        public void Shoot()
        {
            GoalCount++;
        }

        public override string ToString()
        {
           return base.ToString() + $"Postion: {Position} Club: {Club}\nGoals: {GoalCount}\n";
            
        }

        public override void PrintInfo()
        {
            Console.WriteLine(this);
        }
    }
}
