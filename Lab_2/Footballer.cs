﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public class FootBaller: Player
    {
        public FootBaller(string name,string surname,DateTime birthday,string postion,string club):
            base(name,surname,birthday,postion,club)
        {

        }

        public override void Shoot()
        {
            base.Shoot();
            Console.WriteLine("Footballer shoot a goal !!!");
        }
    }
}