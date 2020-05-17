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

namespace Lab10
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected string DBConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mateu\OneDrive\Pulpit\Lab10\Lab10\Database1.mdf;Integrated Security=True";

        public List<Owner> SqlOwnerSelect()
        {
            var list = new List<Owner>();
            using(var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "SELECT [Pesel], [FirstName], [Surname] FROM [dbo].[Owner]";
                cmd.CommandType = CommandType.Text;

                db.Open();
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    list.Add(new Owner(res.GetString(0), res.GetString(1), res.GetString(2)));
                }
            }
            return list;
        }

        public List<T> SqlSelect<T>() where T: new()
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

        public void SqlOwnerInsert(Owner owner)
        {
            using(var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "INSERT INTO [dbo].[Owner]([Pesel], [FirstName], [Surname]) VALUES(@ps, @fn, @sn)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ps", owner.Pesel);
                cmd.Parameters.AddWithValue("@fn", owner.FirstName);
                cmd.Parameters.AddWithValue("@sn", owner.Surname);

                db.Open();
                var res = cmd.ExecuteNonQuery();
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

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void connectionButton_Click(object sender, RoutedEventArgs e)
        {
            var list = SqlOwnerSelect();
            SetGrid(list);
            dg.Items.Refresh();
        }

        private void insertOwnerButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OwnerWindow();
            if(dialog.ShowDialog() == true)
            {
                try
                {
                    SqlOwnerInsert(dialog.owner);
                    MessageBox.Show("Dane wprowadzone pomyślnie");
                    var list = SqlOwnerSelect();
                    SetGrid(list);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void SqlCarInsert(Cars car)
        {
            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "INSERT INTO [dbo].[Cars]([Id], [OwnerPesel], [Brand], [Model], [ProductionYear], [PurchaseDate]) VALUES(@id, @op, @b, @m, @py, @pd)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@id", car.Id);
                cmd.Parameters.AddWithValue("@op", car.OwnerPesel);
                cmd.Parameters.AddWithValue("@b", car.Brand);
                cmd.Parameters.AddWithValue("@m", car.Model);
                cmd.Parameters.AddWithValue("@py", car.ProductionYear);
                cmd.Parameters.AddWithValue("@pd", car.PurchaseDate);

                db.Open();
                var res = cmd.ExecuteNonQuery();
            }
        }

        private void insertCarButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CarWindow();
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    SqlCarInsert(dialog.car);
                    MessageBox.Show("Dane wprowadzone pomyślnie");
                    var list = SqlSelect<Cars>();
                    SetGrid(list);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void showCarsButton_Click(object sender, RoutedEventArgs e)
        {
            var list = SqlSelect<Cars>();
            SetGrid(list);
        }

        private void SqlCarRemove(Cars car)
        {
            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "DELETE FROM [dbo].[Cars] WHERE [Id] = @idCar";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@idCar", car.Id);

                db.Open();
                var res = cmd.ExecuteNonQuery();
            }
            var list = SqlSelect<Cars>();
            SetGrid(list);
        }

        private void SqlOwnerRemove(Owner owner)
        {
            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "DELETE FROM [dbo].[Owner] WHERE [Pesel] = @psO";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@psO", owner.Pesel);

                db.Open();
                var res = cmd.ExecuteNonQuery();
            }
            var list = SqlOwnerSelect();
            SetGrid(list);
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dg.SelectedItem is Cars)
                {
                    SqlCarRemove((Cars)dg.SelectedItem);
                    MessageBox.Show("Wybrany pojazd został usunięty");
                }
                else if (dg.SelectedItem is Owner)
                {
                    SqlOwnerRemove((Owner)dg.SelectedItem);
                    MessageBox.Show("Wybrany właściciel został usunięty");
                }     
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<Cars> SqlCarSelectByProductionYear(int year)
        {
            var list = new List<Cars>();
            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "SELECT * FROM [dbo].[Cars] WHERE [ProductionYear] = @pdY";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@pdY", year);

                db.Open();
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    list.Add(new Cars(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetString(3), res.GetInt32(4), res.GetDateTime(5)));
                }
            }
            return list;
        }

        private List<Cars> SqlCarSelectByPurchaseDate(DateTime date)
        {
            var list = new List<Cars>();
            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "SELECT * FROM [dbo].[Cars] WHERE [PurchaseDate] = @pdY";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@pdY", date);

                db.Open();
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    list.Add(new Cars(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetString(3), res.GetInt32(4), res.GetDateTime(5)));
                }
            }
            return list;
        }


        private void productionDate_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ProductionDateWindow();
            if (dialog.ShowDialog() == true)
            {
                var list = SqlCarSelectByProductionYear(dialog.Year);
                SetGrid(list);
            }
        }

        private void purchaseDate_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new PurchaseDateWindow();
            if (dialog.ShowDialog() == true)
            {
                var list = SqlCarSelectByPurchaseDate(dialog.date);
                SetGrid(list);
            }
        }
    }
}
