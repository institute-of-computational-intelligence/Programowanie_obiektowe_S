using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Liblarian : Person
    {
        public DateTime DateOfEmployment { get; set; }
        public double Salary { get; set; }

        public Liblarian()
        {
            DateOfEmployment = new DateTime();
            Salary = 0;
        }

        public Liblarian(string name,string lastName,DateTime date, double sal): base(name,lastName)
        {
            DateOfEmployment = date;
            Salary = sal;
        }

        public override string ToString()
        {
            return base.ToString()+$"DateOfEmployment: {DateOfEmployment}, salary {Salary}";
        }
    }
}
