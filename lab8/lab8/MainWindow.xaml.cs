using Microsoft.Win32;
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

namespace lab8
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Student> list { get; set; }
        public Student SelectedStudent { get; set; }
        public void Save<T>(T ob, StreamWriter sw)
        {
            Type t = ob.GetType();
            sw.WriteLine($"[[{t.Name}]]");
            foreach (var p in t.GetProperties())
            {
                sw.WriteLine($"[{p.Name}]");
                sw.WriteLine(p.GetValue(ob));
            }
            sw.WriteLine($"[[]]");
        }
        public T Load<T>(StreamReader sr) where T : new()
        {
            T ob = default(T);
            Type tob = null;
            PropertyInfo property = null;

            while (!sr.EndOfStream)
            {
                var ln = sr.ReadLine();
                if (ln == "[[]]")
                    return ob;
                else if (ln.StartsWith("[["))
                {
                    tob = Type.GetType(ln.Trim('[', ']'));
                    if (typeof(T).IsAssignableFrom(tob))
                        ob = (T)Activator.CreateInstance(tob);
                }
                else if (ln.StartsWith("[") && ob != null)
                    property = tob.GetProperty(ln.Trim('[', ']'));
                else if (ob != null && property != null)
                    property.SetValue(ob, Convert.ChangeType(ln, property.PropertyType));
            }
            return default(T);
            
        }
        public MainWindow()
        {
            list = new List<Student>()
            {
                new Student(){LastName="Kowalski", FirstName = "Jan", IndexNo = 1033, Faculty = "WIMiI" },
                new Student(){LastName="Nowak", FirstName = "Michał", IndexNo = 1013, Faculty = "WIMiI" },
                new Student(){LastName="Makieta", FirstName = "Jacek", IndexNo = 1021, Faculty = "WIMiI" }
            };

            InitializeComponent();

            dg.Columns.Add(new DataGridTextColumn() { Header = "Imię", Binding = new Binding("FirstName") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Nazwisko", Binding = new Binding("LastName") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "NrIndeksu", Binding = new Binding("IndexNo") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Wydział", Binding = new Binding("Faculty") });
            dg.AutoGenerateColumns = false;
            dg.ItemsSource = list;
        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new StudentWindow();
            if (dialog.ShowDialog() == true)
            {
                list.Add(dialog.student);
                dg.Items.Refresh();
            }
        }

        private void RemoveStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem is Student)
                list.Remove((Student)dg.SelectedItem);
            dg.Items.Refresh();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dg.SelectedIndex < list.Count)
                SelectedStudent = (Student)dg.SelectedItem;
        }

        private void ShowGradesButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedStudent == null)
                MessageBox.Show("Wybierz studenta z listy");
            else
            {
                var dialog = new GradeWindow(SelectedStudent);
                dialog.Show();
            }

        }

        private void AddGradeButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedStudent == null)
                MessageBox.Show("Wybierz studenta z listy");
            else
            {
                var dialog = new AddGradeWindow(SelectedStudent);
                dialog.ShowDialog();
            }
        }

        private void SaveToFile_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("data.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            foreach (Student s in list)
            {
                sw.WriteLine("[[Student]]");
                sw.WriteLine("[FirstName]");
                sw.WriteLine(s.FirstName);
                sw.WriteLine("[SurName]");
                sw.WriteLine(s.LastName);
                sw.WriteLine("[StudentNo]");
                sw.WriteLine(s.IndexNo);
                sw.WriteLine("[Faculty]");
                sw.WriteLine(s.Faculty);
                sw.WriteLine("[[]]");
            }
            sw.Close();
            fs.Close();
        }

        private void LoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("data.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            list.Clear();
            while (!sr.EndOfStream)
            {
                var ln = sr.ReadLine();
                if(ln == "[[Student]]")
                {
                    Student newStudent = new Student();
                    sr.ReadLine(); // [FirstName]
                    newStudent.FirstName = sr.ReadLine();
                    sr.ReadLine(); // [SurName]
                    newStudent.LastName = sr.ReadLine();
                    sr.ReadLine(); // [StudentNo]
                    newStudent.IndexNo = int.Parse(sr.ReadLine());
                    sr.ReadLine(); // [Faculty]
                    newStudent.Faculty = sr.ReadLine();
                    sr.ReadLine(); // [[]]
                    list.Add(newStudent);
                }
            }
            dg.Items.Refresh();
            sr.Close();
            fs.Close();
        }

        private void SaveToFileSer_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("data.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            foreach (Student s in list)
            {
                Save<Student>(s, sw);
            }
            sw.Close();
            fs.Close();
        }

        private void LoadFromFileSer_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("data.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            list.Clear();
            while (!sr.EndOfStream)
            {
                Student s = Load<Student>(sr);
                list.Add(s);
            }
            dg.Items.Refresh();
            sr.Close();
            fs.Close();
        }

        private void SaveToXml_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("data.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            serializer.Serialize(fs, list);
            fs.Close();
        }

        private void LoadFromXml_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("data.xml"))
            {
                FileStream fs = new FileStream("data.xml", FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
                list = (List<Student>)serializer.Deserialize(fs);
                fs.Close();
                dg.ItemsSource = list;
                dg.Items.Refresh();
            }
        }
    }
}
