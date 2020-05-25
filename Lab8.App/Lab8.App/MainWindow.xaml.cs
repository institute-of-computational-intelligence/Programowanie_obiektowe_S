using Lab8.DAL.Repo;
using Lab8.DAL.Serializers;
using Lab8.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Xml.Serialization;
using Lab8.Model.Attributes;

namespace Lab8.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Student> Students { get; set; }
        private StreamEnumerable<Student> _streamEnumerable;
        private FileStream _fileStream;
        private StreamReader _streamReader;
        private IRepository<Student> repository;
        public MainWindow()
        {
            var _connString = ConfigurationManager.ConnectionStrings["FileDbConnectionStr"].ConnectionString;
            repository = new Repository<Student>(_connString);
            InitializeComponent();
            Students = repository.SqlSelect();
            SetGrid(Students);
        }

        private void B_addStudentWindowShow_Click(object sender, RoutedEventArgs e)
        {
            var addStudentWindow = new AddStudentWindow();
            if (addStudentWindow.ShowDialog() == true)
            {
                Students.Add(addStudentWindow.Student);
                dg_Students.Items.Refresh();
            }
        }

        private void B_removeStudentWindowShow_Click(object sender, RoutedEventArgs e)
        {
            if (dg_Students.SelectedItem is Student studentToRemove)
            {
                repository.SqlDelete(studentToRemove);
                dg_Students.ItemsSource = repository.SqlSelect();
                dg_Students.Items.Refresh();
            }
        }

        private void B_addGradeWindowShow_Click(object sender, RoutedEventArgs e)
        {
            if (dg_Students.SelectedItem != null && dg_Students.SelectedItem is Student selectedStudent)
            {
                var addGradeWindow = new AddGradeWindow(selectedStudent);
                if (addGradeWindow.ShowDialog() == true)
                {
                    dg_Students.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Zaznacz studenta.");
            }
        }

        private void B_loadFromFlatFileDialog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (openFileDialog.ShowDialog() == true)
                {
                    Students.Clear();
                    using (var fileStream = new FileStream(openFileDialog.FileName, FileMode.OpenOrCreate))
                    {
                        using (var streamReader = new StreamReader(fileStream))
                        {
                            while (!streamReader.EndOfStream)
                            {
                                Student student = StreamSerializer.Load<Student>(streamReader);
                                if (student != null)
                                {
                                    Students.Add(student);
                                }
                            }

                            dg_Students.Items.Refresh();
                            MessageBox.Show("Data Loaded");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void B_saveToFlatFileDialog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (saveFileDialog.ShowDialog() == true)
                {
                    using (var fileStream = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate))
                    {
                        using (var streamWriter = new StreamWriter(fileStream))
                        {
                            foreach (var student in Students)
                            {
                                StreamSerializer.Save(student, streamWriter);
                            }

                            MessageBox.Show("Data Saved");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void B_saveToXmlFileDialog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (saveFileDialog.ShowDialog() == true)
                {
                    using (var fileStream = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate))
                    {
                        var xmlSerializer = new XmlSerializer(typeof(List<Student>));
                        xmlSerializer.Serialize(fileStream, Students);
                        MessageBox.Show("Data Saved");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void B_loadFromXMLFileDialog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (openFileDialog.ShowDialog() == true && File.Exists(openFileDialog.FileName))
                {
                    Students.Clear();
                    using (var fileStream = new FileStream(openFileDialog.FileName, FileMode.OpenOrCreate))
                    {
                        var xmlSerializer = new XmlSerializer(typeof(List<Student>));
                        if (xmlSerializer.Deserialize(fileStream) is List<Student> students && students.Count > 0)
                        {
                            Students.AddRange(students);
                            dg_Students.Items.Refresh();
                            MessageBox.Show("Data Loaded");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void B_loadFromFlatFileEnumDialog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (openFileDialog.ShowDialog() == true)
                {
                    Students.Clear();
                    dg_Students.Items.Refresh();
                    _fileStream = new FileStream(openFileDialog.FileName, FileMode.OpenOrCreate);

                    _streamReader = new StreamReader(_fileStream);
                    _streamEnumerable = new StreamEnumerable<Student>(_streamReader);
                    MessageBox.Show("Streaming is open");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void B_loadAnotherStudenFromFile_Click(object sender, RoutedEventArgs e)
        {
            if (_streamEnumerable == null)
            {
                MessageBox.Show("steam not loaded");
            }
            else
            {
                var enumerator = _streamEnumerable.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    Students.Add(enumerator.Current);
                    dg_Students.Items.Refresh();
                }

            }
        }

        private void B_closeStream_Click(object sender, RoutedEventArgs e)
        {
            _streamReader.Close();
            _fileStream.Close();
            MessageBox.Show("Streams closed");
        }

        private void DatePicker_filterGrid_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datePicker_filterGrid.SelectedDate.HasValue)
            {
                dg_Students.ItemsSource = repository
                        .SqlSelect(new Tuple<string, string, object, string>("DateOfBirth", "=", datePicker_filterGrid.SelectedDate.Value.ToString("yyyy-MM-dd"), null));
            }
            else
            {
                dg_Students.ItemsSource = repository.SqlSelect();
            }
            dg_Students.Items.Refresh();

        }

        private void SetGrid<T>(List<T> list) where T : new()
        {
            Type type = typeof(T);
            if(type.GetCustomAttribute<DbTabAttribute>() == null)
                return;
            foreach (var prop in type.GetProperties())
            {
                var col = prop.GetCustomAttribute<DbColAttribute>();
                if(col != null)
                    dg_Students.Columns.Add(new DataGridTextColumn(){Header = col.Title ?? prop.Name, Binding = new Binding(prop.Name)});
            }
            dg_Students.AutoGenerateColumns = false;
            dg_Students.ItemsSource = list;
        }
    }
}
