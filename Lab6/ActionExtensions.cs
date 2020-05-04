using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public static class ActionExtensions
    {
        public static IList<TObj> Set<TObj, TAg>(this TAg aggregatedObj) where TObj : IInfo where TAg : IAction
        {
            var aggregatedObjType = aggregatedObj.GetType();
            var propertyInfo = aggregatedObjType.GetProperties().FirstOrDefault(p => p.PropertyType == typeof(IList<TObj>));
            var propertyValue = propertyInfo?.GetValue(aggregatedObj);
            return propertyValue as IList<TObj>;
        }
        public static S Add<C, S>(S container, C element) where S : IAction where C : IInfo
        {
            container.Set<C, IAction>().Add(element);

            return container;
        }

        public static C AddInfo<C>(C obj, IAction container) where C : IInfo
        {
            container.Set<C, IAction>().Add(obj);
            return obj;
        }

        public static void ForEach<T>(IList<T> list, Action<T> action)
        {
            foreach (T e in list)
                action(e);
        }

        public static C Get<C>(this IAction container, Func<C, bool> searchPredicate = null) where C:IInfo
        {
            return searchPredicate == null ?
                container.Set<C, IAction>().FirstOrDefault() :
                container.Set<C, IAction>().FirstOrDefault(searchPredicate);
        }

        public static IList<C> GetList<C>(IAction container, Func<C, bool> searchPredicate = null) where C : IInfo
        {
            return searchPredicate == null ? container.Set<C, IAction>() : container.Set<C, IAction>().Where(searchPredicate).ToList();
        }

        public static C Remove<C>(IAction container, Func<C, bool> searchFunc) where C : IInfo
        {
            var obj = container.Set<C, IAction>().SingleOrDefault(searchFunc);
            if (obj != null)
            {
                container.Set<C, IAction>().Remove(obj);
            }
            return obj;
        }

        public static IList<T> AddRange<T>(this IList<T> list, IList<T> elementsToAdd)
        {
            foreach (var element in elementsToAdd)
            {
                list.Add(element);
            }
            return list;
        }
        public static S AddRange<C, S>(this S container, IList<C> element) where S : IAction where C : IInfo
        {
            container.Set<C, IAction>().AddRange(element);
            return container;
        }
    }
}
