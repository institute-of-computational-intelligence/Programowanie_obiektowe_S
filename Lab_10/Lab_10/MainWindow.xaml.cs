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

namespace Lab_10
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected string DBConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\GIT Studia\Programowanie_obiektowe_S\Lab_10\Lab_10\DB.mdf;Integrated Security=True";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            var students = SqlStudentSelect();

            SetGrid(students);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddStudent();

            if (dialog.ShowDialog() == true)
            {
                SqlStudentInsert(dialog.Student);

                var students = SqlStudentSelect<Student>();
                SetGrid(students);
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem is Student)
            {
                SqlStudentRemove((Student)dg.SelectedItem);

                var students = SqlStudentSelect<Student>();
                SetGrid(students);
            }
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {

        }

        public List<Student> SqlStudentSelect()

        {

            var list = new List<Student>();



            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "SELECT [IndexNo],[Name],[LastName],[Dep] FROM [dbo].[Student]";
                cmd.CommandType = CommandType.Text;

                db.Open();
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    list.Add(new Student()
                    {
                        IndexNo = res.GetInt32(0),
                        Name = res.GetString(1),
                        LastName = res.GetString(2),
                        Dep = res.GetString(3)

                    });
                }
            }
            return list;
        }
        public void SqlStudentInsert(Student student)
        {
            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "INSERT INTO [dbo].[Student]([Name],[LastName],[Dep]) VALUES(@fn,@sn,@f)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@fn", student.Name);
                cmd.Parameters.AddWithValue("@sn", student.LastName);
                cmd.Parameters.AddWithValue("@f", student.Dep);

                db.Open();

                var res = cmd.ExecuteNonQuery();
            }
        }
        public void SqlStudentRemove(Student student)
        {
            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();

                cmd.CommandText = "DELETE FROM [dbo].[Student] WHERE [IndexNo]=@id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", student.IndexNo);

                db.Open();

                var res = cmd.ExecuteNonQuery();
                MessageBox.Show($"Deleted: {res} record(s).");

            }
        }

        public List<T> SqlStudentSelect<T>() where T : new()
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
                cmd.CommandText = $"SELECT {string.Join(",", names)} from [dbo].[{t.Name}]";
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
    }
}
