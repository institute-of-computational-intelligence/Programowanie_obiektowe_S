using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public static class PrintActionExtensions
    {
        public static C Print<C>(this C obj)  where C : IInfo
        {
            Console.WriteLine(obj);
            return obj;
        }

        public static IList<S> Print<S>(this IList<S> set) where S : IInfo
        {
            foreach (S e in set)
                e.DisplayInfo();
            return set;
        }

        public static C PrintInfo<C>(this C obj) where C : IInfo
        {
            obj.DisplayInfo();
            return obj;
        }

        public static IList<C> PrintInfo<C>(this IList<C> set) where C : IInfo
        {
            foreach (C e in set)
                e.DisplayInfo();
            return set;
        }
    }
}
