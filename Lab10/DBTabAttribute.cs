using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class DBTabAttribute : System.Attribute
    {
        public string Name { get; set; }
    }

    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class DBColAttribute : System.Attribute
    {
        public String Title { get; set; }
        public String Name { get; set; }
        public String ForeignKey { get; set; }
    }
}
