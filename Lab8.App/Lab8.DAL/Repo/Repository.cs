using Lab8.Model.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Lab8.DAL.Repo
{
    public class Repository<T> : IRepository<T> where T : new()
    {
        private readonly string _connectionString;
        public Repository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<T> SqlSelect(params Tuple<string, string, object, string>[] filters)
        {
            var list = new List<T>();
            Type type = typeof(T);
            if (type.GetCustomAttribute<DbTabAttribute>() == null)
            {
                return null;
            }
            var colProps = type.GetProperties().Where(p => p.GetCustomAttribute<DbColAttribute>() != null).ToList();
            var colPropsNames = colProps.Select(p => $"[{p.GetCustomAttribute<DbColAttribute>().Name ?? p.Name}]").ToList();
            var sqlQuery = $"SELECT {string.Join(",", colPropsNames)} FROM [dbo].[{type.Name}]";
            if (filters != null && filters.Length > 0)
            {
                sqlQuery += $" WHERE ";
                foreach (var filter in filters)
                {
                    sqlQuery += $"{filter.Item1} {filter.Item2} @{filter.Item1} {filter.Item4}";
                }
            }
            using (var dbConnection = new SqlConnection(_connectionString))
            {
                var cmd = dbConnection.CreateCommand();
                cmd.CommandText = sqlQuery;
                cmd.CommandType = CommandType.Text;
                if (filters != null && filters.Length > 0)
                {
                    foreach (var filter in filters)
                    {
                        cmd.Parameters.AddWithValue($"@{filter.Item1}", filter.Item3);
                    }
                }
                if (dbConnection.State == ConnectionState.Closed)
                {
                    dbConnection.Open();
                }
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    var obj = new T();
                    int i = 0;
                    colProps.ForEach(p => p.SetValue(obj, res[i++]));
                    list.Add(obj);
                }
            }
            return list;
        }

        public bool SqlInsert(T entity)
        {
            try
            {
                Type type = typeof(T);
                if (type.GetCustomAttribute<DbTabAttribute>() == null)
                {
                    throw new Exception("Given type is not an entity");
                }

                var colProps = type.GetProperties().Where(p => p.GetCustomAttribute<DbColAttribute>() != null).ToList();
                var colsData = new Dictionary<string, object>();
                colProps.ForEach(col =>
                {
                    colsData.Add($"{col.GetCustomAttribute<DbColAttribute>().Name ?? col.Name}",
                        col.GetValue(entity));
                });
                using (var dbConnection = new SqlConnection(_connectionString))
                {
                    var cmd = dbConnection.CreateCommand();
                    cmd.CommandText =
                        $"INSERT INTO [dbo].[{type.Name}] ({string.Join(",", colsData.Keys.Select(c => $"[{c}]"))}) VALUES ({string.Join(",", colsData.Keys.Select(c => $"@{c}"))})";
                    cmd.CommandType = CommandType.Text;
                    foreach (var kvpCol in colsData)
                    {
                        cmd.Parameters.AddWithValue($"@{kvpCol.Key}", kvpCol.Value);
                    }
                    if (dbConnection.State == ConnectionState.Closed)
                    {
                        dbConnection.Open();
                    }

                    var res = cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool SqlDelete(T entity)
        {
            try
            {
                Type type = typeof(T);
                if (type.GetCustomAttribute<DbTabAttribute>() == null)
                {
                    throw new Exception("Given type is not an entity");
                }

                var colProps = type.GetProperties().Where(p => p.GetCustomAttribute<DbColAttribute>() != null).ToList();
                var colsData = new Dictionary<string, object>();
                colProps.ForEach(col =>
                {
                    colsData.Add($"{col.GetCustomAttribute<DbColAttribute>().Name ?? col.Name}",
                        col.GetValue(entity));
                });
                using (var dbConnection = new SqlConnection(_connectionString))
                {
                    var cmd = dbConnection.CreateCommand();
                    cmd.CommandText =
                        $"DELETE FROM [dbo].[{type.Name}] WHERE ";
                    cmd.CommandType = CommandType.Text;
                    int i = 0;
                    foreach (var kvpCol in colsData)
                    {
                        cmd.CommandText += $"{kvpCol.Key} = @{kvpCol.Key}";
                        if (i <= colsData.Count - 2) cmd.CommandText += " AND ";
                        cmd.Parameters.AddWithValue($"@{kvpCol.Key}", kvpCol.Value);
                        ++i;
                    }
                    if (dbConnection.State == ConnectionState.Closed)
                    {
                        dbConnection.Open();
                    }

                    var res = cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (SqlException)
            {
                return false;
            }

        }
    }
}
