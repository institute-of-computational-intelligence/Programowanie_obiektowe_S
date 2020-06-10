using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;

namespace Lab8
{
    public partial class MainWindow : Window
    {
        public List<Student> s_list { get; set; }

        public MainWindow()
        {
            s_list = new List<Student>()
            {
                //new Student(){ FirstName = "Jan", LastName = "Kowalski", IndexNumber = 10005, Course = "Informatyka" },
                //new Student(){ FirstName = "Marian", LastName = "Broda", IndexNumber = 10006, Course = "Informatyka" },
                //new Student(){ FirstName = "Jan", LastName = "Leń", IndexNumber = 10007, Course = "Informatyka" },
                //new Student(){ FirstName = "Lesław", LastName = "Czesław", IndexNumber = 10008, Course = "Informatyka" }
            };

            InitializeComponent();

            dg.Columns.Add(new DataGridTextColumn() {Header = "Imię:", Binding = new Binding("FirstName")});
            dg.Columns.Add(new DataGridTextColumn() {Header = "Nazwisko:", Binding = new Binding("LastName")});
            dg.Columns.Add(new DataGridTextColumn() {Header = "Numer Indeksu:", Binding = new Binding("IndexNumber")});
            dg.Columns.Add(new DataGridTextColumn() {Header = "Kierunek:", Binding = new Binding("Course")});
            dg.AutoGenerateColumns = false;
            dg.ItemsSource = s_list;           
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new StudentWindow();
            if(dialog.ShowDialog() == true)
            {
                s_list.Add(dialog.student);
                dg.Items.Refresh();
            }
        }

        private void RemoveStudent_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem is Student)
                s_list.Remove((Student)dg.SelectedItem);
            dg.Items.Refresh();
        }

        private void ShowNotes_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem is Student)
            {
                Student student = (Student)dg.SelectedItem;
                var dialog = new NotesWindow(student.Notes);
                if (dialog.ShowDialog() == true)
                {
                    student.Notes = dialog.notes;
                }
            }
        }

        private void AddNotes_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem is Student)
            {
                Student student = (Student)dg.SelectedItem;
                var dialog = new AddNote();
                if (dialog.ShowDialog() == true)
                {
                    student.Notes.Add(dialog.note);
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Plik txt | *.txt";
            saveFileDialog.ShowDialog();

            try
            {
                FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fileStream);

                foreach (Student s in s_list)
                {
                    streamWriter.WriteLine("[[Student]]");
                    streamWriter.WriteLine("[FirstName]");
                    streamWriter.WriteLine(s.FirstName);
                    streamWriter.WriteLine("[LastName]");
                    streamWriter.WriteLine(s.LastName);
                    streamWriter.WriteLine("[IndexNumber]");
                    streamWriter.WriteLine(s.IndexNumber);
                    streamWriter.WriteLine("[Course]");
                    streamWriter.WriteLine(s.Course);
                    streamWriter.WriteLine("[[]]");
                }

                streamWriter.Close();
                MessageBox.Show("Pomyślnie zapisano do pliku txt");
            }
            catch
            {
                MessageBox.Show("Błąd zapisywania do pliku txt");
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Plik txt | *.txt";
            openFileDialog.ShowDialog();

            try
            {
                FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open);
                StreamReader streamReader = new StreamReader(fileStream);

                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    line = streamReader.ReadLine();
                    line = streamReader.ReadLine();
                    string fn = line;
                    line = streamReader.ReadLine();
                    line = streamReader.ReadLine();
                    string ln = line;
                    line = streamReader.ReadLine();
                    line = streamReader.ReadLine();
                    int iN = Convert.ToInt32(line);
                    line = streamReader.ReadLine();
                    line = streamReader.ReadLine();
                    string c = line;
                    line = streamReader.ReadLine();
                    s_list.Add(new Student(fn, ln, iN, c));
                }

                streamReader.Close();
                MessageBox.Show("Pomyślnie wczytano z pliku txt");
                dg.Items.Refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd ładowania z pliku txt");
            }
        }

        private void XmlSaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Plik xml | *.xml";
            saveFileDialog.ShowDialog();

            try
            {
                FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
                xmlSerializer.Serialize(fileStream, s_list);
                fileStream.Close();

                MessageBox.Show("Pomyślnie zapisano do pliku xml");
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd zapisywania do pliku xml");
            }
        }

        private void XmlLoadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Plik xml | *.xml";
            openFileDialog.ShowDialog();

            try
            {
                if (File.Exists("./dane.xml"))
                {
                    FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open);
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
                    s_list = (List<Student>)xmlSerializer.Deserialize(fileStream);
                    fileStream.Close();
                }

                MessageBox.Show("Pomyślnie wczytano z pliku xml");
                dg.ItemsSource = s_list;
                dg.Items.Refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd ładowania z pliku xml");
            }
        }
    }
}
