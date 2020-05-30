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

namespace lab_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Student> list { get; set; }
        public MainWindow()
        {
            list = new List<Student>
            {
                new Student("Jan", "Kowalski", 1033,  "WIMiI"),
                new Student("Michał", "Nowak", 1013,  "WIMiI"),
                new Student("Jacek", "Makieta", 1021,  "WIMiI")
            };

            InitializeComponent();

            dg.AutoGenerateColumns = false;
            dg.ItemsSource = list;

            dg.Columns.Add(new DataGridTextColumn() { Header = "Imię", Binding = new Binding("FristName") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Nazwisko", Binding = new Binding("SurName") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Nr indeksu", Binding = new Binding("StudentNo") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Wydział", Binding = new Binding("Faculty") });
            
            
        }

        private void AddStudent_Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new StudentWindow();
            if (dialog.ShowDialog() == true)
            {
                list.Add(dialog.student);
                dg.Items.Refresh();
            }
        }

        private void RemoveStudent_Button_Click(object sender, RoutedEventArgs e)
        {
            if(dg.SelectedItem is Student)
                list.Remove((Student)dg.SelectedItem);
            dg.Items.Refresh();
        }
    }
}
