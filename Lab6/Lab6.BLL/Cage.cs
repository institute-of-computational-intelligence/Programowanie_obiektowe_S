using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Extensions;

namespace Lab6.BLL
{
    public class Cage : IAction, IInfo
    {
        public Guid Id { get; set; }
        public int Capacity { get; set; }
        public bool RequireCleaning { get; set; }
        public IList<Animal> Animals { get; set; }
        public CageSupervisor CageSupervisor { get; set; }

        public Cage(int capacity, bool requireCleaning, IList<Animal> animals, CageSupervisor cageSupervisor = null)
        {
            Capacity = capacity;
            Id = Guid.NewGuid();
            RequireCleaning = requireCleaning;
            Animals = animals;
            CageSupervisor = cageSupervisor;
        }
       

        public override string ToString()
        {
            var str = $"Id: {Id}, Capacity: {Capacity}, Require cleaning: {RequireCleaning} \r\n Animals: \r\n";
            str += string.Join("\r\n", Animals.Select(a => a.ToString()));
            return str;
        }

        public void Display()
        {
            Console.WriteLine(this);
        }
    }
}
