using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Zoo : IInfo, IAction
    {
        private string name;
        private IList<Cage> cages = new List<Cage>();
        private IList<Employee> employees = new List<Employee>();
        private IList<Animal> animals = new List<Animal>();

        public string Name { get => name; set => name = value; }
        public IList<Cage> Cages { get => cages; set => cages = value; }
        public IList<Employee> Employees { get => employees; set => employees = value; }
        public IList<Animal> Animals { get => animals; set => animals = value; }

        public Zoo()
        {
        }

        public Zoo(string name)
        {
            this.name = name;
        }

        public Cage BuildCage(int capacity, bool dirty = false)
        {
            Cage cage = new Cage(capacity, dirty);
            this.Set<Cage, Zoo>().Add(cage);
            return cage;
        }

        public Employee HireEmployee(string name, string surname, DateTime born)
        {
            Employee employee = new CageSupervisor(name, surname, born, DateTime.Now, new List<Cage>());
            this.Set<Employee, Zoo>().Add(employee);
            return employee;
        }

        public void ExpandCage(Cage cage, int byNumber)
        {
            foreach(Cage c in cages)
            {
                if (c.Id == cage.Id)
                    c.Capacity += byNumber;
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine(this);
        }

        public void DisplayAllCages()
        {
            foreach (Cage c in cages)
                Console.WriteLine(c);

        }
        public void DisplayAllEmployees()
        {
            foreach (Employee e in employees)
                Console.WriteLine(e);

        }

        public override string ToString()
        {
            return $"Zoo: {name} klatek- {cages.Count} pracownikow- {employees.Count}";
        }
    }
}
