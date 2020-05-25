using System;

namespace Lab8.Model.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DbColAttribute : Attribute
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string ForeignKey { get; set; }
    }
}
