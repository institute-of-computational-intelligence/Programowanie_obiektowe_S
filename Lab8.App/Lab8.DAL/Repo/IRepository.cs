using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Lab8.DAL.Repo
{
    public interface IRepository<T> where T : new()
    {
        List<T> SqlSelect(params Tuple<string, string, object, string>[] filters);
        bool SqlInsert(T entity);
        bool SqlDelete(T entity);

    }
}
