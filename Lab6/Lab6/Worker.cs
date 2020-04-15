using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public class Worker
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birth { get; set; }
        public DateTime DateOfEmployment { get; set; }

        public Worker(string name, string surname, DateTime birth, DateTime dateOfEmployment)
        {
            Name = name;
            Surname = surname;
            Birth = birth;
            DateOfEmployment = dateOfEmployment;
        }

        public void PrintInfo()
        {

        }
    }
}
