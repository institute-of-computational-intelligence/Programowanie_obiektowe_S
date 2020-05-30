using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Lectuer : Person
    {
        public string Title { get; set; }
        public string WorkPlace { get; set; }

        public Lectuer(): base() { }
        public Lectuer(string name, string surname, DateTime dateofbirth, string title,string work) : base(name,surname,dateofbirth) 
        {
            this.Title = title;
            this.WorkPlace = work;
        }

        public override string ToString()
        {
            return base.ToString()+$"Title: {Title} Work Place: {WorkPlace}";
        }

        public virtual void Details()
        {
            Console.WriteLine(this);
        }
    }
}
