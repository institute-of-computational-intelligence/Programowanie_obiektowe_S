using System;
using System.Collections.Generic;
using System.Text;

namespace Zad03 {
    class Magazine : Position {
        private int number;


        public Magazine(string title, int id, string publisher, DateTime releaseDate, int number): base(title, id, publisher, releaseDate) {
            this.number = number;
        }

        public int Number { get => number; set => number = value; }

        public override string ToString() {
            return base.ToString() + $", Number: {number}";
        }
        public override void Details() {
            Console.WriteLine(this);
            Console.WriteLine("--------------------");
        }
    }
}
