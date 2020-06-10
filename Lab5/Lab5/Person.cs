using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    class Person : IInfo
    {
        private string name;
        private string surname;
        protected string dateOfBirth;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }

        public Person()
        {
            name = "--";
            surname = "--";
            dateOfBirth = "--";
        }

        public Person(string name_, string surname_, string dateOB_)
        {
            name = name_;
            surname = surname_;
            dateOfBirth = dateOB_;
        }

        public override string ToString()
        {
            return $"Personal Data| Name: {name} {surname}, Date of birth: {dateOfBirth}";
        }

        public virtual void Details()
        {
            Console.WriteLine(this);
        }
    }
}
