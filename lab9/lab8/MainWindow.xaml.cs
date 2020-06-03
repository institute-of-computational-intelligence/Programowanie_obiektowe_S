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
using System.Reflection;
using System.IO;
using System.Xml.Serialization;
namespace lab8
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Student> list { get; set; }

        public MainWindow()
        {
            list = new List<Student>()
            {
                new Student(){Name="Jan",Surname="Kowalski",Index=1033, Faculty="WIMiI"},
                new Student(){Name="Michał",Surname="Nowak",Index=1013, Faculty="WIMiI"},
                new Student(){Name="Jacek",Surname="Makieta",Index=1021, Faculty="WIMiI"}

            };
            InitializeComponent();
            dg.Columns.Add(new DataGridTextColumn() { Header = "Imię", Binding = new Binding("Name") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Nazwisko", Binding = new Binding("Surname") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Nr indeksu", Binding = new Binding("Index") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Wydział", Binding = new Binding("Faculty") });

            dg.AutoGenerateColumns = false;
            dg.ItemsSource = list;
        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem is Student)
            {
                list.Remove((Student)dg.SelectedItem);
                dg.Items.Refresh();

            }

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new StudentWindow();
            if (dialog.ShowDialog() == true)
            {
                list.Add(dialog.student);
                dg.Items.Refresh();
            }
        }

        private void grades_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new GradesWindow();
            if (dg.SelectedItem is Student)
            {
                dialog.ShowDialog();


            }



        }

        private void save_file_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileStream fs = new FileStream("data.txt", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("[[Student]]");
                /*foreach (var w in list)
                {
                    sw.WriteLine("[[Name]]");
                    sw.WriteLine(w.Name);
                    sw.WriteLine("[[Surname]]");
                    sw.WriteLine(w.Surname);
                    sw.WriteLine("[[Index]]");
                    sw.WriteLine(w.Index);
                    sw.WriteLine("[[Faculty]]");
                    sw.WriteLine(w.Faculty);
                    sw.WriteLine("[[]]");
                }*/
                foreach (var w in list)
                {
                    Save(w, sw);
                }
                sw.Close();
                MessageBox.Show("Udalo sie zapisac plik txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void load_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileStream fs = new FileStream("data.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                // Student s = null;
                var loaded = new List<Student>();
                while (!sr.EndOfStream)
                {
                    /*var ln = sr.ReadLine();
                    if (ln == "[[Student]]")
                    {
                        s = new Student();
                    }
                    else if (ln == "[[Name]]")
                    {
                        ln = sr.ReadLine();
                        s.Name = ln;
                    }
                    else if (ln == "[[Surname]]")
                    {
                        ln = sr.ReadLine();
                        s.Surname = ln;
                    }
                    else if (ln == "[[Index]]")
                    {
                        ln = sr.ReadLine();
                        s.Index = int.Parse(ln);
                    }
                    else if (ln == "[[Faculty]]")
                    {
                        ln = sr.ReadLine();
                        s.Faculty = ln;
                    }
                    else if (ln == "[[]]")
                    {
                        list.Add(s);
                        s = new Student();
                    }*/

                    loaded.Add(Load<Student>(sr));

                }
                list = loaded;
                dg.ItemsSource = list;
                //dg.Items.Refresh();
                sr.Close();
                //fs.Close();
                MessageBox.Show("Udalo sie wczytac plik txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

}

        private void Save<T>(T ob, StreamWriter sw)
        {
            var t = ob.GetType();

            sw.WriteLine($"[[{t.FullName}]]");

            foreach (var p in t.GetProperties())
            {
                sw.WriteLine($"[{p.Name}]");
                sw.WriteLine(p.GetValue(ob));
            }

            sw.WriteLine("$[[]]");
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
                {
                    return ob;
                }
                else if (ln.StartsWith("[["))
                {
                    tob = Type.GetType(ln.Trim('[', ']'));

                    if (typeof(T).IsAssignableFrom(tob))
                    {
                        ob = (T)Activator.CreateInstance(tob);
                    }
                }
                else if (ln.StartsWith("[") && ob != null)
                {
                    property = tob.GetProperty(ln.Trim('[', ']'));
                }
                else if (ob != null && property != null)
                {
                    property.SetValue(ob, Convert.ChangeType(ln, property.PropertyType));
                }
            }

            return default(T);
        }

        private void load_xaml_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var fileStream = new FileStream("data.xml", FileMode.Open);
                var serializer = new XmlSerializer(typeof(List<Student>));
                list = (List<Student>)serializer.Deserialize(fileStream);
                fileStream.Close();

                dg.ItemsSource = list;

                MessageBox.Show("Udalo sie wczytac plik xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void save_xaml_Click(object sender, RoutedEventArgs e)
        {
             try
            {
                var fileStream = new FileStream("data.xml", FileMode.Create);
                var serializer = new XmlSerializer(typeof(List<Student>));
                serializer.Serialize(fileStream, list);
                fileStream.Close();

                MessageBox.Show("Udalo sie zapisac plik txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
