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

namespace Lab9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
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

            StudentDataGrid.AutoGenerateColumns = false;
            StudentDataGrid.ItemsSource = Students;

            StudentDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Imię", Binding = new Binding("Name") });
            StudentDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Nazwisko", Binding = new Binding("Surname") });
            StudentDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Nr Indeksu", Binding = new Binding("IndexNo") });
            StudentDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Wydział", Binding = new Binding("Faculty") });

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new StudentWindow();

            if (dialog.ShowDialog() == true)
            {
                Students.Add(dialog.Student);
                StudentDataGrid.Items.Refresh();
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (StudentDataGrid.SelectedItem is Student)
            {
                Students.Remove((Student)StudentDataGrid.SelectedItem);
                StudentDataGrid.Items.Refresh();
            }
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var fileStream = new FileStream("data.txt", FileMode.Create);
                var streamWriter = new StreamWriter(fileStream);

                foreach (var student in Students)
                {
                    // wersja z zadania 2
                    // student.WriteToFile(streamWriter);

                    // wersja z zadania 4
                    Save(student, streamWriter);
                }

                streamWriter.Close();

                MessageBox.Show("File has been saved successfuly");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void LoadFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var loadedStudents = new List<Student>();
                //Student student = null;

                var fileStream = new FileStream("data.txt", FileMode.Open);
                var streamReader = new StreamReader(fileStream);

                while (!streamReader.EndOfStream)
                {
                    // wersja dla zadania 4
                    loadedStudents.Add(Load<Student>(streamReader));

                    // werjsa dla zadania 3
                    //var line = streamReader.ReadLine();

                    //if (line == "[[Student]]") student = new Student();
                    //else if (line == "[Name]")
                    //{
                    //    line = streamReader.ReadLine();
                    //    student.Name = line;
                    //}
                    //else if (line == "[Surname]")
                    //{
                    //    line = streamReader.ReadLine();
                    //    student.Surname = line;
                    //}
                    //else if (line == "[Faculty]")
                    //{
                    //    line = streamReader.ReadLine();
                    //    student.Faculty = line;
                    //}
                    //else if (line == "[IndexNo]")
                    //{
                    //    line = streamReader.ReadLine();
                    //    student.IndexNo = int.Parse(line);
                    //}
                    //else if (line == "[[]]")
                    //{
                    //    loadedStudents.Add(student);
                    //    student = null;
                    //}
                }

                Students = loadedStudents;
                StudentDataGrid.ItemsSource = Students;

                streamReader.Close();

                MessageBox.Show("File has been loaded successfuly");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Save<T>(T obj, StreamWriter streamWriter)
        {
            var type = obj.GetType();

            streamWriter.WriteLine($"[[{type.FullName}]]");

            foreach (var property in type.GetProperties())
            {
                streamWriter.WriteLine($"[{property.Name}]");
                streamWriter.WriteLine(property.GetValue(obj));
            }

            streamWriter.WriteLine("[[]]");
        }

        private T Load<T>(StreamReader streamReader) where T : new()
        {
            T obj = default(T);
            Type typeOfObj = null;
            PropertyInfo property = null;

            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();

                if (line == "[[]]")
                {
                    return obj;
                }
                else if (line.StartsWith("[["))
                {
                    typeOfObj = Type.GetType(line.Trim('[', ']'));

                    if (typeof(T).IsAssignableFrom(typeOfObj))
                    {
                        obj = (T)Activator.CreateInstance(typeOfObj);
                    }
                }
                else if (line.StartsWith("[") && obj != null)
                {
                    property = typeOfObj.GetProperty(line.Trim('[', ']'));
                }
                else if (obj != null && property != null)
                {
                    property.SetValue(obj, Convert.ChangeType(line, property.PropertyType));
                }
            }

            return default(T);
        }


        private void SaveXML_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var fileStream = new FileStream("data.xml", FileMode.Create);
                var serializer = new XmlSerializer(typeof(List<Student>));
                serializer.Serialize(fileStream, Students);
                fileStream.Close();

                MessageBox.Show("File has been saved successfuly");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadXML_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var fileStream = new FileStream("data.xml", FileMode.Open);
                var serializer = new XmlSerializer(typeof(List<Student>));
                Students = (List<Student>)serializer.Deserialize(fileStream);
                fileStream.Close();

                StudentDataGrid.ItemsSource = Students;

                MessageBox.Show("File has been loaded successfuly");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
    