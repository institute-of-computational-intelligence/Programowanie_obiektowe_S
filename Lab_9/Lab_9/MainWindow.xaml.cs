using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace Lab_9
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Student> Students { get; set; }
        public MainWindow()
        {
            Students = new List<Student>
            {
                new Student("Jan", "Kowalski", 1033,  "WIMiI"),
                new Student("Michał", "Nowak", 1013,  "WIMiI"),
                new Student("Jacek", "Makieta", 1021,  "WIMiI")
            };

            InitializeComponent();
        
            dg.Columns.Add(new DataGridTextColumn() { Header = "Imię", Binding = new Binding("Name") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Nazwisko", Binding = new Binding("Surname") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Nr indeksu", Binding = new Binding("IndexNumber") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Wydział", Binding = new Binding("Dep") });

            dg.AutoGenerateColumns = false;
            dg.ItemsSource = Students;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new StudentWindow();
            if (dialog.ShowDialog() == true)
            {
                Students.Add(dialog.Student);
                dg.Items.Refresh();
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem is Student)
            {
                Students.Remove((Student)dg.SelectedItem);
                dg.Items.Refresh();
            }
        }

        private void SaveToXML_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var stream = new FileStream("data.xml", FileMode.Create);
                var serialize = new XmlSerializer(typeof(List<Student>));
                serialize.Serialize(stream, Students);
                stream.Close();

                MessageBox.Show("Properly saved file");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void SaveToFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var loadStream = new FileStream("data.txt", FileMode.Create);
                var write = new StreamWriter(loadStream);

                foreach (var student in Students)
                {
                    Save(student, write);
                }

                write.Close();

                MessageBox.Show("Properly saved file");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadFromXML_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var loadStream = new FileStream("data.xml", FileMode.Open);
                var serialize = new XmlSerializer(typeof(List<Student>));
                Students = (List<Student>)serialize.Deserialize(loadStream);
                loadStream.Close();

                dg.ItemsSource = Students;

                MessageBox.Show("Properly loaded file");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var loadedStudents = new List<Student>();

                var stream = new FileStream("data.txt", FileMode.Open);
                var readStream = new StreamReader(stream);

                while (!readStream.EndOfStream)
                {
                    loadedStudents.Add(Load<Student>(readStream));
                }
                Students = loadedStudents;
                dg.ItemsSource = Students;

                readStream.Close();
                MessageBox.Show("Properly loaded file");
            }          
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Save<T>(T obj, StreamWriter str)
        {
            var type = obj.GetType();

            str.WriteLine($"[[{type.FullName}]]");

            foreach (var property in type.GetProperties())
            {
                str.WriteLine($"[{property.Name}]");
                str.WriteLine($"[{property.GetValue(obj)}]");
            }
            str.WriteLine("[[]]");
        }

        private T Load<T>(StreamReader str) where T: new()
        {
            T obj = default(T);
            Type objType = null;
            PropertyInfo property = null;

            while (!str.EndOfStream)
            {
                var line = str.ReadLine();

                if(line == "[[]]")
                {
                    return obj;
                }
                else if (line.StartsWith("[["))
                {
                    objType = Type.GetType(line.Trim('[', ']'));

                    if (typeof(T).IsAssignableFrom(objType))
                    {
                        obj = (T)Activator.CreateInstance(objType);
                    }
                }
                else if (line.StartsWith("[") && obj != null)
                {
                    property = objType.GetProperty(line.Trim('[', ']'));
                }
                else if (obj != null && property != null)
                {
                    property.SetValue(obj, Convert.ChangeType(line, property.PropertyType));
                }
            }

            return default(T);
        }
    }
}
