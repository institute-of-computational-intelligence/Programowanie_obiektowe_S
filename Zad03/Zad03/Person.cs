using System;
using System.Collections.Generic;
using System.Text;

namespace Zad03 {
    class Person {
        protected string firstName;
        protected string lastName;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public Person() {
            firstName = "null";
            lastName = "null";
        }
        public Person(string firstName, string lastName) {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public override string ToString() {
            return $"First name: {firstName}, Last name: {lastName}";
        }
    }
}
