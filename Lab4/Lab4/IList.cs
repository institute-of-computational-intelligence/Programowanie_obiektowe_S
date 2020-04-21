using System;
using System.Collections.Generic;

namespace Lab4
{
    public interface IList<Type>:IEnumerable<Type>
    {
        void Add(Type item);
        void Remove(Type item);
        void Insert(Type item, int beforeIndex);
        Type Get(int index);
        Type this[int i] { get; set; }
    }
}
