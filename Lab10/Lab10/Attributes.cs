using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DBTabAttribute : Attribute
    {
        public string Name { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class DBCollAttribute : Attribute
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string ForeignKey { get; set; }
    }
}
