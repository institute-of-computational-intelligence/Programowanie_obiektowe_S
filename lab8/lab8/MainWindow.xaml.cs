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

namespace lab8
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Student> list { get; set; }
        public Student s;
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
                list.Remove((Student)dg.SelectedItem);
            
            dg.Items.Refresh();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new StudentWindow();
            if(dialog.ShowDialog()==true)
            {
                list.Add(dialog.student);
                dg.Items.Refresh();
            }
        }
        
        private void grades_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new GradesWindow();
            if(dg.SelectedItem is Student)
            {
                dialog.ShowDialog();

           
            }
            
           

        }
    }
}
