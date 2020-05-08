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

namespace Lab_8
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

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new StudentWindow();

            if(dialog.ShowDialog() == true)
            {
                Students.Add(dialog.Student);
                dg.Items.Refresh();
            }
        }

        private void RemoveStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if(dg.SelectedItem is Student)
            {
                Students.Remove((Student)dg.SelectedItem);
                dg.Items.Refresh();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(dg.SelectedItem is Student)
            {
                var dialog = new Marks(((Student)dg.SelectedItem).Grades);
                dialog.ShowDialog();
            }
        }
    }
}
