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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected string DBConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\i5\Documents\Obiektowe\Programowanie_obiektowe_S\Lab10\Lab10\Database.mdf;Integrated Security=True";
        public MainWindow()
        {
            InitializeComponent();

            dgData.IsReadOnly = true;
            dgData.CanUserAddRows = false;
        }

        public List<Student> SqlStudentSelect()
        {
            var list = new List<Student>();

            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "SELECT [StudentNo],[FirstName],[SurName],[Faculty] from [dbo].[Student]";
                cmd.CommandType = CommandType.Text;

                db.Open();
                var res = cmd.ExecuteReader();

                while (res.Read())
                {
                    list.Add(new Student()
                    {
                        StudentNo = res.GetInt32(0),
                        FirstName = res.GetString(1),
                        SurName = res.GetString(2),
                        Faculty = res.GetString(3),
                    }
                    );
                }
            }
            return list;
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
            dgData.Columns.Clear(); // TODO
            Type t = typeof(T);
            if (t.GetCustomAttribute<DBTabAttribute>() == null)
                return;

            foreach (var p in t.GetProperties())
            {
                var coll = p.GetCustomAttribute<DBCollAttribute>();
                if (coll != null)
                    dgData.Columns.Add(new DataGridTextColumn() { Header = coll.Title ?? p.Name, Binding = new Binding(p.Name) });
            }

            dgData.AutoGenerateColumns = false;
            dgData.ItemsSource = list;
        }

        public void SqlStudentInsert(Student stud)
        {
            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "INSERT INTO [dbo].[Student]([FirstName],[SurName],[Faculty]) VALUES(@fn,@sn,@f)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@fn", stud.FirstName);
                cmd.Parameters.AddWithValue("@sn", stud.SurName);
                cmd.Parameters.AddWithValue("@f", stud.Faculty);

                db.Open();
                var res = cmd.ExecuteNonQuery();

                MessageBox.Show($"Inserted: {res} record(s).");
            }
        }

        public void SqlStudentRemove(Student stud)
        {
            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "DELETE FROM [dbo].[Student] WHERE [StudentNo]=@id_st";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@id_st", stud.StudentNo);

                db.Open();
                var res = cmd.ExecuteNonQuery();

                MessageBox.Show($"Deleted: {res} record(s).");
            }
        }

        private void btnDbConnect_Click(object sender, RoutedEventArgs e)
        {
            var list = SqlStudentSelect<Student>();

            SetGrid<Student>(list);
        }

        private void btnOpenDialog_Click(object sender, RoutedEventArgs e)
        {
            AddStudent dialog = new AddStudent();

            if (dialog.ShowDialog() == true)
            {
                SqlStudentInsert(new Student() { FirstName = dialog.tbName.Text, SurName = dialog.tbSurname.Text, Faculty = "WIMiI" });

                // Zdecydowanie nie jest to dobry pomysl, aby za kazdym insertem robic select'a
                var list = SqlStudentSelect<Student>();

                SetGrid<Student>(list);
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dgData.SelectedItem is Student)
            {
                SqlStudentRemove((Student)dgData.SelectedItem);

                // Zdecydowanie nie jest to dobry pomysl, aby za kazdym deletem robic select'a
                var list = SqlStudentSelect<Student>();

                SetGrid<Student>(list);
            }
        }
    }
}
