using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_6
{
    public class Employee
    {
        public string Firstname { get;  }
        public string Lastname { get;  }
        public DateTime DateOfBirth { get;  }
        public DateTime DateOfEmployment { get;  }

        public Employee(string firstanme, string lastname, DateTime dateOfBirth, DateTime dateOfEmployment)
        {
            Firstname = firstanme;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
            DateOfEmployment = dateOfEmployment;
        }
    }
}
