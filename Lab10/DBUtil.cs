using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class DBUtil
    {
        private string DBConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Studia\\2 Rok\\Programowanie Obiektowe\\Repozytorium\\Programowanie_obiektowe_S\\Lab10\\Database.mdf\";Integrated Security=True";

        public DBUtil() { }

        public DBUtil(string connectionString)
        {
            DBConnectionString = connectionString;
        }

        public List<T> GetObjects<T>(string search = "") where T: new()
        {
            List <T> list = new List<T>();

            Type t = typeof(T);
            if (t.GetCustomAttribute<DBTabAttribute>() == null)
                return null;
            var prop = t.GetProperties().Where(p => p.GetCustomAttribute<DBColAttribute>() != null).ToList();

            var names = prop.Select(p => $"[{p.GetCustomAttribute<DBColAttribute>().Name ?? p.Name}]").ToList();
            //var conditions = prop.Select(p => $"{p.GetCustomAttribute<DBColAttribute>().Name ?? p.Name} = @{p.GetCustomAttribute<DBColAttribute>().Name ?? p.Name}").ToList();
            string condidion = "";

            if(search != "")
            {
                condidion = $"WHERE {prop.Select(p => $"{p.GetCustomAttribute<DBColAttribute>().Name ?? p.Name}").First()} = @p1";
            }

            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = $"SELECT {string.Join(",", names)} FROM  [dbo].[{t.Name}] {condidion}";
                cmd.CommandType = System.Data.CommandType.Text;
                if (condidion != "")
                {
                    cmd.Parameters.AddWithValue("@p1", search);
                }
                db.Open();
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    var ob = new T();
                    int i = 0;
                    prop.ForEach(p => p.SetValue(ob, res[i++]));
                    list.Add(ob);
                }
            }
            return list;
        }

        public void InsertObject<T>(T obj) where T: new()
        {
            Type t = typeof(T);
            if (t.GetCustomAttribute<DBTabAttribute>() == null)
                return;
            var prop = t.GetProperties().Where(p => p.GetCustomAttribute<DBColAttribute>() != null).ToList();

            

            var names = prop.Select(p => $"[{p.GetCustomAttribute<DBColAttribute>().Name ?? p.Name}]").ToList();
            var parameters = prop.Select(p => $"@{p.GetCustomAttribute<DBColAttribute>().Name ?? p.Name}").ToList();

            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = $"INSERT INTO [dbo].[{t.Name}] ({string.Join(",",names)}) VALUES({string.Join(",",parameters)})";
                cmd.CommandType = System.Data.CommandType.Text;
                prop.ForEach(p => cmd.Parameters.AddWithValue($"@{p.GetCustomAttribute<DBColAttribute>().Name ?? p.Name}", p.GetValue(obj)));
                db.Open();
                var res = cmd.ExecuteNonQuery();
            }
        }

        public void RemoveObject<T>(T obj)
        {
            Type t = typeof(T);
            if (t.GetCustomAttribute<DBTabAttribute>() == null)
                return;
            var prop = t.GetProperties().Where(p => p.GetCustomAttribute<DBColAttribute>() != null).ToList();
            var conditions = prop.Select(p => $"{p.GetCustomAttribute<DBColAttribute>().Name ?? p.Name} = @{p.GetCustomAttribute<DBColAttribute>().Name ?? p.Name}").ToList();

            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = $"DELETE FROM [dbo].[{t.Name}] WHERE {string.Join(" and ",conditions)}";
                cmd.CommandType = System.Data.CommandType.Text;
                prop.ForEach(p => cmd.Parameters.AddWithValue($"@{p.GetCustomAttribute<DBColAttribute>().Name ?? p.Name}", p.GetValue(obj)));
                db.Open();
                var res = cmd.ExecuteNonQuery();
            }
        }
        
    }
}
