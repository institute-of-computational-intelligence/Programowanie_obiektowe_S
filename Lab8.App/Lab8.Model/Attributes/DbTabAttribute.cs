using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Model.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DbTabAttribute: Attribute
    {
        public string Name { get; set; }
    }
}
