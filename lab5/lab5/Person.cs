using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Person : IInfo
    {
        protected string firstName;
        protected string lastName;
        protected DateTime dateOfBirth;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Person()
        {
            firstName = "";
            lastName = "";
        }
        public Person(string fName, string lName, DateTime bDate)
        {
            firstName = fName;
            lastName = lName;
            dateOfBirth = bDate;
        }

        public override string ToString()
        {
            return $"{firstName} {lastName}, urodzony: {dateOfBirth}";
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine(this);
        }
    }
}
