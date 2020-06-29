using System;
using System.Collections.Generic;
using System.Text;

namespace Zad03 {
    class Author : Person {
        private string nationality;
        public Author() : base() {
            nationality = "null";
        }
        public Author(string firstName, string lastName, string nationality) : base(firstName, lastName) {
            this.nationality = nationality;
        }
       
        public override string ToString() {
            return base.ToString() + $", Nationality: {nationality}";
        }
    }
}
