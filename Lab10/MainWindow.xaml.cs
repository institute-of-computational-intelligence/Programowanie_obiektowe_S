using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Reflection;
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
        public List<Student> list { get; set; }

        public string DBConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Studia\PO\Programowanie_obiektowe_S\Lab10\Database.mdf;Integrated Security = True";

        public List<Student> SqlStudentSelect()
        {
            var list = new List<Student>();
            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "SELECT [Name],[Surname],[IndexNumber],[Major] FROM [dbo].[Students]";
                cmd.CommandType = CommandType.Text;

                db.Open();
                var res = cmd.ExecuteReader();
                while (res.Read()) 
                {
                    list.Add(new Student() { Name = res.GetString(0), Surname = res.GetString(1), IndexNumber = res.GetInt32(2), Major = res.GetString(3) });
                }
            }
            return list;
        }

        public void SqlStudentInsert(Student student)
        {
            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "INSERT INTO [dbo].[Students]([Name],[Surname],[IndexNumber],[Major]) VALUES(@nm,@sn,@in,@mj)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@nm", student.Name);
                cmd.Parameters.AddWithValue("@sn", student.Surname);
                cmd.Parameters.AddWithValue("@in", student.IndexNumber);
                cmd.Parameters.AddWithValue("@mj", student.Major);

                db.Open();
                var res = cmd.ExecuteNonQuery();
            }
        }

        public List<T> SqlSelect<T>() where T: new()
        {
            var list = new List<T>();

            Type t = typeof(T);
            if (t.GetCustomAttribute<DBTabAttribute>() == null)
                return null;
            var prop = t.GetProperties().Where(p => p.GetCustomAttribute<DBTabAttribute>() != null).ToList();
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
                    prop.ForEach(p => p.SetValue(ob, res[i + 1]));
                    list.Add(ob);
                }
            }
            return list;
        }

        public void SetGrid<T>(List<T> list)
        {
            //StudentsDataGrid.Columns.Clear();
            Type t = typeof(T);
            if (t.GetCustomAttribute<DBTabAttribute>() == null)
                return;
            foreach(var p in t.GetProperties())
            {
                var coll = p.GetCustomAttribute<DBCollAttribute>();
                if (coll != null)
                    StudentsDataGrid.Columns.Add(new DataGridTextColumn() { Header = coll.Title ?? p.Name, Binding = new Binding(p.Name) });
            }

            StudentsDataGrid.AutoGenerateColumns = false;
            StudentsDataGrid.ItemsSource = list;
        }

        public MainWindow()
        {
            list = new List<Student>()
            {
                new Student(){ Surname = "Kowalski", Name = "Jan", IndexNumber = 1033, Major = "WIMiI" },
                new Student(){ Surname = "Nowak", Name = "Michał", IndexNumber = 1013, Major = "WIMiI" },
                new Student(){ Surname = "Makieta", Name = "Jacek", IndexNumber = 1021, Major = "WIMiI" }
            };

            InitializeComponent();

            StudentsDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Name", Binding = new Binding("Name") });
            StudentsDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Surname", Binding = new Binding("Surname") });
            StudentsDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Index Number", Binding = new Binding("IndexNumber") });
            StudentsDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Major", Binding = new Binding("Major") });
            StudentsDataGrid.AutoGenerateColumns = false;
            StudentsDataGrid.ItemsSource = list;
        }

        private void ButtonAddStudent_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new StudentWindow();
            if (dialog.ShowDialog() == true)
            {
                list.Add(dialog.student);
                StudentsDataGrid.Items.Refresh();
            }
        }

        private void ButtonRemoveStudent_Click(object sender, RoutedEventArgs e)
        {
            if (StudentsDataGrid.SelectedItem is Student)
                list.Remove((Student)StudentsDataGrid.SelectedItem);
            StudentsDataGrid.Items.Refresh();
        }

        private void ButtonSaveToFile_Click(object sender, RoutedEventArgs e)
        {
            FileStream fileStream = new FileStream("data.txt", FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            foreach (var item in list)
            {
                streamWriter.WriteLine("[[Student]]");
                streamWriter.WriteLine("[Name]");
                streamWriter.WriteLine(item.Name);
                streamWriter.WriteLine("[Surname]");
                streamWriter.WriteLine(item.Surname);
                streamWriter.WriteLine("[Index Number]");
                streamWriter.WriteLine(item.IndexNumber);
                streamWriter.WriteLine("[Major]");
                streamWriter.WriteLine(item.Major);
                streamWriter.WriteLine("[[]]");
            }

            streamWriter.Close();
        }

        private void ButtonLoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            FileStream fileStream = new FileStream("data.txt", FileMode.Open);
            StreamReader streamReader = new StreamReader(fileStream);

            Student student = new Student();
            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();
                line = streamReader.ReadLine();
                line = streamReader.ReadLine();
                student.Name = line;
                line = streamReader.ReadLine();
                line = streamReader.ReadLine();
                student.Surname = line;
                line = streamReader.ReadLine();
                line = streamReader.ReadLine();
                student.IndexNumber = Convert.ToInt32(line);
                line = streamReader.ReadLine();
                line = streamReader.ReadLine();
                student.Major = line;
                line = streamReader.ReadLine();
                list.Add(new Student(student));
            }

            streamReader.Close();
            StudentsDataGrid.Items.Refresh();
        }

        private void ButtonAddRow_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new StudentWindow();
            if (dialog.ShowDialog() == true)
            {
                SqlStudentInsert(dialog.student);
                //SetGrid<Student>(SqlSelect<Student>());
                SetGrid<Student>(SqlStudentSelect());
            }
        }

        private void ButtonUpload_Click(object sender, RoutedEventArgs e)
        {
            foreach(var item in list)
            {
                try
                {
                    SqlStudentInsert(item);
                }
                catch (Exception) { }
            }
        }

        private void ButtonDownload_Click(object sender, RoutedEventArgs e)
        {
            var list = SqlStudentSelect();
            this.list = new List<Student>(list);
            StudentsDataGrid.AutoGenerateColumns = false;
            StudentsDataGrid.ItemsSource = this.list;
            StudentsDataGrid.Items.Refresh();
        }
    }
}
