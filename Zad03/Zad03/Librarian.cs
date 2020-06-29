using System;
using System.Collections.Generic;
using System.Text;

namespace Zad03 {
    class Librarian : Person {
        private DateTime employmentDate;
        private double salary;
        public Librarian() : base() {
            employmentDate = new DateTime();
            salary = 0.0;
        }

        public Librarian(string firstName, string lastName, DateTime employmentDate, double salary): base(firstName, lastName) {
            this.employmentDate = employmentDate;
            this.salary = salary;
        }

        public DateTime EmploymentDate { get => employmentDate; set => employmentDate = value; }
        public double Salary { get => salary; set => salary = value; }
        public override string ToString() {
            return base.ToString() + $", Employment date: {employmentDate.ToString("dd/MM/yyyy")}, Salary: {salary}";
        }
    }
}
