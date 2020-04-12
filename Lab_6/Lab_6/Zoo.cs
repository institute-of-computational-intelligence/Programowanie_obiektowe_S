using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_6
{
    public class Zoo
    {
        public string Name { get;  }
        public List<Cage> Cages { get; private set; }
        public List<Employee> Employees { get; private set; }

        public Zoo(string name)
        {
            Name = name;
        }

        public Cage BuildCage(int capacity, bool requiresCleaning)
        {
            return new Cage(capacity, requiresCleaning, new List<Animal>());
        }
        public void ExpnadCage(Cage cage, int newCapacity)
        {
            cage.Capacity = newCapacity;
        }

        public Employee HireEmployee(string firstname, string lastname,DateTime dateOfBirth)
        {
            return new Employee(firstname, lastname, dateOfBirth,DateTime.UtcNow);
        }
        public void AddAnimal(Cage cage,Animal animal)
        {
            cage.Animals.Add(animal);
        }
        public void DisplayAllCages()
        {

        }
    }
}
