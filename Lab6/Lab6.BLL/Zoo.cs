using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Extensions;

namespace Lab6.BLL
{
    public class Zoo : IInfo, IAction
    {
        public string Name { get; set; }
        public IList<Employee> Employees { get; set; }
        public IList<Cage> Cages { get; set; }

        public IList<Animal> Animals { get; set; }

        public Zoo(string name)
        {
            Name = name;
            Animals = Animals ?? new List<Animal>();
            Employees = Employees ?? new List<Employee>();
            Cages = Cages ?? new List<Cage>();
        }

        public Zoo(string name, IList<Employee> employees, IList<Cage> cages, IList<Animal> animals)
        {
            Animals = animals;
            Employees = employees;
            Cages = cages;
            Name = name;
        }

        public void DisplayAllCages()
        {
            string str = "Cages: \r\n";
            str += string.Join("\r\n", Cages.Select(cage => cage.ToString()));
            Console.WriteLine(str);
        }

        public void DisplayEmploee(Employee employee)
        {
            employee.Display();
        }

        public void DisplayAllEmploee()
        {
            foreach (var employee in Employees)
                DisplayEmploee(employee);
        }

        public void DisplayCage(Cage cage)
        {
            cage.Display();
        }

        public override string ToString()
        {
            string str = $"Name: {Name} \r\n Cages: \r\n";
            str += string.Join("\r\n", Cages.Select(cage => cage.ToString()));
            str += "\r\n Employees: \r\n";
            str += string.Join("\r\n", Employees.Select(emp => emp.ToString()));
            str += "\r\n Animals: \r\n";
            str += string.Join("\r\n", Animals.Select(a => a.ToString()));
            return str;
        }

        public void Display()
        {
            Console.WriteLine(this);
        }
        public void ExpandCage(Cage cage, int expandValue)
        {
            cage.Capacity = expandValue;
        }

        public Cage BuildCage(int capacity, bool requireCleaning, CageSupervisor cageSupervisor = null)
        {
            Cage newCage = new Cage(capacity, requireCleaning, new List<Animal>(), cageSupervisor);
            this.Set<Cage, Zoo>().Add(newCage);
            return newCage;
        }

        public Employee HireEmployee(string firstName, string lastName, DateTime dateOfBirth)
        {
            Employee employee = new CageSupervisor(firstName, lastName, dateOfBirth, DateTime.Now, new List<Cage>());
            this.Set<Employee, Zoo>().Add(employee);
            return employee;
        }

        

    }
}
