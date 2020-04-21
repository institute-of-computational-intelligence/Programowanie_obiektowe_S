using System;
using System.Collections.Generic;
using System.Text;

namespace Generic.Extensions
{
    public static class PrintActionExtensions
    {
        public static C Print<C>(this C obj) where C : IInfo
        {
            Console.WriteLine(obj);
            return obj;
        }

        public static IList<S> Print<S>(this IList<S> set) where S : IInfo
        {
            set.ForEach(d => Console.WriteLine(d));
            return set;
        }

        public static C PrintInfo<C>(this C obj) where C : IInfo
        {
            obj.DisplayInfo();
            return obj;
        }

        public static IList<C> PrintInfo<C>(this IList<C> set) where C : IInfo
        {
            set.ForEach(d => d.DisplayInfo());
            return set;
        }
    }
}
