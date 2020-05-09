using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace Lab8
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public IList<Student> Students { get; set; }
        public MainWindow()
        {
            Students = new List<Student>();



            InitializeComponent();
            dg.Columns.Add(new DataGridTextColumn() { Header = "Imię", Binding = new Binding("FirstName") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Nazwisko", Binding = new Binding("Surname") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "NrIndeksu", Binding = new Binding("IndexNumber") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Wydział", Binding = new Binding("Faculty") });
            dg.AutoGenerateColumns = false;
            dg.ItemsSource = Students;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new StudentWindow();
            if (dialog.ShowDialog() == true)
            {
                Students.Add(dialog.student);
                dg.Items.Refresh();
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem is Student)
                Students.Remove((Student)dg.SelectedItem);
            dg.Items.Refresh();
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem is Student student)
            {
                // var dialog = new GradeWindow(student.Grades);
                //dialog.ShowDialog();
            }
        }

        private void AddGradeButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem is Student)
            {
                var dialog = new AddGradeWindow();

                if (dialog.ShowDialog() == true)
                {
                    var student = (Student)dg.SelectedItem;
                    //  student.Grades.Add(dialog.grade);
                }
            }
        }

        private void SaveToFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.ShowDialog();
                var fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
                var sw = new StreamWriter(fs);

                //Instrukcje do zadania 2
                /* 
                foreach (var item in Students)
                {
                    item.SaveToFile(sw);
                }
                */

                //instrukcje do zadania 4
                foreach (var student in Students)
                {
                    Save(student, sw);
                }


                MessageBox.Show("Dane zostały zapisane do pliku!");

                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Save<T>(T ob, StreamWriter sw)
        {
            Type t = ob.GetType();
            sw.WriteLine($"[[{t.FullName}]]");
            foreach (var property in t.GetProperties())
            {
                sw.WriteLine($"[{property.Name}]");
                sw.WriteLine(property.GetValue(ob));
            }
            sw.WriteLine("[[]]");
        }

        private void LoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.ShowDialog();
                var fs = new FileStream(openFileDialog.FileName, FileMode.Open);
                var sr = new StreamReader(fs);
                Student student = null;

                //wersja dla zadania 3
                //while (!sr.EndOfStream)
                //{

                //    var ln = sr.ReadLine();
                //    if (ln == "[[Lab8.Student]]")
                //        student = new Student();
                //    else if (ln == "[FirstName]")
                //    {
                //        ln = sr.ReadLine();
                //        student.FirstName = ln;
                //    }
                //    else if (ln == "[Surname]")
                //    {
                //        ln = sr.ReadLine();
                //        student.Surname = ln;
                //    }
                //    else if (ln == "[IndexNumber]")
                //    {
                //        ln = sr.ReadLine();
                //        student.IndexNumber = int.Parse(ln);
                //    }
                //    else if (ln == "[Faculty]")
                //    {
                //        ln = sr.ReadLine();
                //        student.Faculty = ln;
                //    }
                //    else if (student.CheckValue())
                //    {
                //        Students.Add(student);
                //        dg.Items.Refresh();
                //    }     
                //}

                //wersja dla zadania 4
                while(!sr.EndOfStream)
                {
                    Students.Add(Load<Student>(sr));
                    dg.Items.Refresh();
                }
                
                sr.Close();
                MessageBox.Show("Dane poprawnie wczytane z pliku!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private T Load<T>(StreamReader sr) where T : new()
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

        private void SaveToXML_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.ShowDialog();
                var fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
                var serializer = new XmlSerializer(typeof(List<Student>));
                serializer.Serialize(fs, Students);
                fs.Close();
                MessageBox.Show("Dane pomyślnie zapisane!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void LoadFromXML_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.ShowDialog();
                FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
                Students = (List<Student>)serializer.Deserialize(fs);
                fs.Close();
                dg.ItemsSource = Students;
                MessageBox.Show("Dane wczytane pomyślnie!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
