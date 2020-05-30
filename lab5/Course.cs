using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Course : IInfo
    {
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Specjality { get; set; }
        public int term { get; set; }
        public int Hour { get; set; }

        public Course(string name, string subj,string spec,int ter,int hour)
        {
            this.Name = name;
            this.Subject = subj;
            this.Specjality = spec;
            this.term = ter;
            this.Hour = hour;
        }
        public Course() { }

        public override string ToString()
        {
            return $"Name: {Name} Subject: {Subject} Specjality: {Specjality} term: {term} Hour:{Hour}";
        }

        public virtual void details()
        {
            Console.WriteLine(this);
        }
    }
}
