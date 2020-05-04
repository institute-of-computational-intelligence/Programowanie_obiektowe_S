using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public abstract class Employee:IInfo
    {
        private string name;
        private string surname;
        private DateTime born;
        private DateTime hired;

        public Employee()
        {
        }

        public Employee(string name, string surname, DateTime born, DateTime hired)
        {
            this.name = name;
            this.surname = surname;
            this.born = born;
            this.hired = hired;
        }

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public DateTime Born { get => born; set => born = value; }
        public DateTime Hired { get => hired; set => hired = value; }

        public virtual void DisplayInfo()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return $"Pracownik: {name} {surname} ur.{born} zatrudniony: {hired}";
        }
    }
}
