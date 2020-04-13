using System;
using System.Collections.Generic;

namespace Lab6
{
    public class Zoo : IInfo, IAction
    {
        public string Name { get; set; }
        public IList<Cage> Cages { get; private set; }
        public IList<Employee> Employees { get; private set; }
        public Zoo(string name)
        {
            Name = name;
            Cages = new List<Cage>();
            Employees = new List<Employee>();
        }

        public Cage BuildNewCage(int capacity, bool requiresCleaning) => new Cage(capacity, requiresCleaning, new List<Animal>());

        public void ExtendCage(int capacity, int id)
        {
            foreach (var item in Cages)
            {
                if (item.ID == id)
                {
                    item.Capacity = capacity;
                    Console.WriteLine($"Cage number:{item.ID} has been extended\n");
                }
            }            
        }



        public void ExpandCage(Cage cage, int capacity)
        {
            cage.Capacity = capacity;
            Console.WriteLine($"Cage{cage} has been extended\n");
        }

        public Employee HireEmployee(string firstName, string lastName, DateTime birthDate) => new Employee(firstName, lastName, birthDate, DateTime.Now);

        public void AddAnimal(Cage cage, Animal animal) => cage.Animals.Add(animal);

        public void PrintAllCages()
        {
            foreach (var item in Cages)
            {
                Console.WriteLine(item);
            }
        }

        public void PrintAllEmplyee()
        {
            foreach (var item in Employees)
            {
                Console.WriteLine(item);
            }
        }

        public override string ToString()
        {
            return $"Zoo:{Name}\n Cages and Employee";
        }
        public void Details()
        {
            Console.WriteLine(this);
            PrintAllCages();
            PrintAllEmplyee();
        }
    }
}