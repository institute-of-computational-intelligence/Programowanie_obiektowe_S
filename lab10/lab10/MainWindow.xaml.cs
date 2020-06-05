using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab10
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var car = SqlCarsSelect();

            SetGrid(car);
        }
        protected string DBConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=W:\programowanie obiektowe\Programowanie_obiektowe_S\lab10\lab10\Database1.mdf;Integrated Security = True";

        public List<Cars> SqlCarsSelect()
        {
            
            var list = new List<Cars>();
            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "SELECT [Id], [Registration_number], [Owner], [Brand], [Model], [Date] FROM [dbo].[Cars]";
                cmd.CommandType = CommandType.Text;

                db.Open();
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    list.Add(new Cars(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetString(3), res.GetString(4), res.GetDateTime(5)));
                }
            }
            return list;
        }
        public List<T> SqlCarsSelect<T>() where T : new()
        {
            var list = new List<T>();

            Type t = typeof(T);
            if (t.GetCustomAttribute<DBTabAttribute>() == null)
                return null;
            var prop = t.GetProperties().Where(p => p.GetCustomAttribute<DBCollAttribute>() != null).ToList();
            var names = prop.Select(p => $"[{p.GetCustomAttribute<DBCollAttribute>().Name ?? p.Name}]").ToList();

            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = $"SELECT {string.Join(",", names)} FROM [dbo].[{t.Name}]";
                cmd.CommandType = CommandType.Text;

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

        public void SqlCarsInsert(Cars cars)
        {
            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "INSERT INTO [dbo].[Cars]( [Registration_number], [Owner], [Brand], [Model], [Date]) VALUES( @rn, @o, @b, @m, @d)";
                cmd.CommandType = CommandType.Text;

                
                cmd.Parameters.AddWithValue("@rn", cars.Registration_number);
                cmd.Parameters.AddWithValue("@o", cars.Owner);
                cmd.Parameters.AddWithValue("@b", cars.Brand);
                cmd.Parameters.AddWithValue("@m", cars.Model);
                cmd.Parameters.AddWithValue("@d", cars.Date);



                db.Open();
                var res = cmd.ExecuteNonQuery();
            }
        }

        private void Add_car_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Add_car();

            if (dialog.ShowDialog() == true)
            {

                SqlCarsInsert(dialog.car);
               
                var list = SqlCarsSelect<Cars>();
                SetGrid(list);

            }

        }
        public void SetGrid<T>(List<T> list)
        {
            dg.Columns.Clear();
            Type t = typeof(T);
            if (t.GetCustomAttribute<DBTabAttribute>() == null)
                return;
            foreach (var p in t.GetProperties())
            {
                var coll = p.GetCustomAttribute<DBCollAttribute>();
                if (coll != null)
                    dg.Columns.Add(new DataGridTextColumn() { Header = coll.Title ?? p.Name, Binding = new Binding(p.Name) });

            }

            dg.AutoGenerateColumns = false;
            dg.ItemsSource = list;
        }

        private void Remove_car_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem is Cars)
            {
                SqlCarsRemove((Cars)dg.SelectedItem);

                var students = SqlCarsSelect<Cars>();
                SetGrid(students);
            }
        }
        public void SqlCarsRemove(Cars cars)
        {
            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "DELETE FROM [dbo].[Cars] WHERE [Id]=@id";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@id", cars.Id);

                db.Open();
                var res = cmd.ExecuteNonQuery();

               
            }
        }
 


    }
}
    

