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

namespace Lab08
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public IList<Student> StudentList { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            StudentList = new List<Student>()
            {
                new Student() { Name = "Janusz", Surname = "Kowalski", IndexNumber = 18621, Faculty = "WIMiI" },
                new Student() { Name = "Andrzej", Surname = "Nowak", IndexNumber = 13528, Faculty = "WIMiI" },
                new Student() { Name = "John", Surname = "Doe", IndexNumber = 16322, Faculty = "WIMiI" },
            };

            studentsGrid.Columns.Add(new DataGridTextColumn() { Header = "Name", Binding = new Binding("Name") });
            studentsGrid.Columns.Add(new DataGridTextColumn() { Header = "Surname", Binding = new Binding("Surname") });
            studentsGrid.Columns.Add(new DataGridTextColumn() { Header = "Index number", Binding = new Binding("IndexNumber") });
            studentsGrid.Columns.Add(new DataGridTextColumn() { Header = "Faculty", Binding = new Binding("Faculty") });

            studentsGrid.IsReadOnly = true;
            studentsGrid.CanUserAddRows = false;
            studentsGrid.AutoGenerateColumns = false;
            studentsGrid.ItemsSource = StudentList;
        }

        private void btnRemoveStudent_Click(object sender, RoutedEventArgs e)
        {
            if (studentsGrid.SelectedItem != null && studentsGrid.SelectedItem is Student)
                StudentList.Remove((Student)studentsGrid.SelectedItem);

            studentsGrid.Items.Refresh();
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            StudentWindow dialog = new StudentWindow();

            if (dialog.ShowDialog() == true)
            {
                StudentList.Add(dialog.student);
                studentsGrid.Items.Refresh();
            }
        }

        private void btnAddGrade_Click(object sender, RoutedEventArgs e)
        {
            if (studentsGrid.SelectedItem is Student)
            {
                NewGradeWindow gradeDialog = new NewGradeWindow((Student)studentsGrid.SelectedItem);
                gradeDialog.ShowDialog();
            }
        }

        private void btnShowGrades_Click(object sender, RoutedEventArgs e)
        {
            if (studentsGrid.SelectedItem is Student)
            {
                GradesWindow gradeDialog = new GradesWindow((Student)studentsGrid.SelectedItem);
                gradeDialog.ShowDialog();
            }
        }

        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "TXT files (*.txt)|*.txt";

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    FileStream fileStream = new FileStream(dialog.FileName, FileMode.Create);
                    StreamWriter streamWR = new StreamWriter(fileStream);

                    foreach (var st in StudentList)
                        Save<Student>(st, streamWR);

                    streamWR.Close();

                    MessageBox.Show($"File ({dialog.FileName}) has been saved correctly!");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void Save<T>(T obj, StreamWriter sw)
        {
            Type t = obj.GetType();
            sw.WriteLine($"[[{t.FullName}]]");

            foreach(var p in t.GetProperties())
            {
                sw.WriteLine($"[{p.Name}]");
                sw.WriteLine(p.GetValue(obj));
            }
            sw.WriteLine($"[[]]");
        }

        private T Load<T>(StreamReader sr) where T : new()
        {
            T ob = default(T);
            Type objectType = null;
            PropertyInfo propInfo = null;

            while (!sr.EndOfStream)
            {
                var streamLine = sr.ReadLine();
                if (streamLine == "[[]]")
                    return ob;
                else if (streamLine.StartsWith("[["))
                {
                    objectType = Type.GetType(streamLine.Trim('[', ']'));
                    if (typeof(T).IsAssignableFrom(objectType))
                        ob = (T)Activator.CreateInstance(objectType);
                }
                else if (streamLine.StartsWith("[") && ob != null)
                    propInfo = objectType.GetProperty(streamLine.Trim('[', ']'));
                else if (ob != null && propInfo != null)
                    propInfo.SetValue(ob, Convert.ChangeType(streamLine, propInfo.PropertyType));
            }
            return default(T);
        }

        private void btnLoadFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "TXT files (*.txt)|*.txt";

            if (dialog.ShowDialog() == true)
            {

                try
                {
                    FileStream fileStream = new FileStream(dialog.FileName, FileMode.Open);
                    StreamReader streamReader = new StreamReader(fileStream);

                    IList<Student> tempList = new List<Student>();

                    while (!streamReader.EndOfStream)
                        tempList.Add(Load<Student>(streamReader));

                    StudentList = tempList;
                    studentsGrid.ItemsSource = StudentList;
                    studentsGrid.Items.Refresh();

                    streamReader.Close();

                    MessageBox.Show($"File ({dialog.FileName}) has been loaded correctly!");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void btnSaveXML_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "XML files (*.xml)|*.xml";

            if (dialog.ShowDialog() == true)
            {

                try
                {
                    FileStream stream = new FileStream(dialog.FileName, FileMode.Create);
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));

                    serializer.Serialize(stream, StudentList);

                    MessageBox.Show($"File ({dialog.FileName}) has been saved correctly!");
                    stream.Close();
                }
                catch (InvalidOperationException exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void btnLoadXML_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "XML files (*.xml)|*.xml";

            if (dialog.ShowDialog() == true)
            {
                List<Student> tempList = new List<Student>();

                try
                {
                    FileStream stream = new FileStream(dialog.FileName, FileMode.Open);
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
                    tempList = (List<Student>)serializer.Deserialize(stream);

                    StudentList = tempList;
                    studentsGrid.ItemsSource = StudentList;
                    studentsGrid.Items.Refresh();

                    stream.Close();

                    MessageBox.Show($"File ({dialog.FileName}) has been loaded correctly!");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }            
            }
        }
    }
}
