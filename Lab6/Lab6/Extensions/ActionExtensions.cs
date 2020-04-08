using Lab6.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Extensions
{
    static class ActionExtensions
    {
        public static IList<TObj> Set<TObj, TAg>(this TAg aggregatedObj) 
            where TObj : IInfo where TAg : IAction
        {
            var aggregatedObjType = aggregatedObj.GetType();
            var propertyInfo = aggregatedObjType.GetProperties().FirstOrDefault(p => p.PropertyType == typeof(IList<TObj>));
            var propertyValue = propertyInfo?.GetValue(aggregatedObj);
            
            return propertyValue as IList<TObj>;
        }

        public static C Get<C>(this IAction container, Func<C, bool> searchPredicate = null)
            where C : IInfo
        {
            return searchPredicate == null ?
                container.Set<C, IAction>().FirstOrDefault() :
                container.Set<C, IAction>().FirstOrDefault(searchPredicate);
        }

        public static IList<C> GetList<C>(this IAction container, Func<C, bool> searchPredicate = null)
            where C : IInfo
        {
            return searchPredicate == null ?
                container.Set<C, IAction>() :
                container.Set<C, IAction>().Where(searchPredicate).ToList();
        }

        public static S Add<C, S>(this S container, C element)
            where S : IAction where C : IInfo
        {
            container.Set<C, IAction>().Add(element);
            return container;
        }

        public static C Remove<C>(this IAction container, Func<C, bool> searchPredicate) 
            where C : IInfo
        {
            var obj = container.Set<C, IAction>().SingleOrDefault(searchPredicate);

            if(obj != null)
            {
                container.Set<C, IAction>().Remove(obj);
            }

            return obj;
        }
    }
}
