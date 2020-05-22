using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Person : IInfo
    {
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public string DateOfBirth { get; set; } = "";

        public Person(string name_, string surname_, string dateOfBirth_)
        {
            Name = name_;
            Surname = surname_;
            DateOfBirth = dateOfBirth_;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Surname: {Surname}, Date of birth: {DateOfBirth}";
        }

        public void WriteInfo()
        {
            Console.WriteLine(this);
        }
    }
}
