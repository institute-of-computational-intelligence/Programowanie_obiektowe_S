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

namespace Lab8
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

            StudentDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Imię", Binding = new Binding("Name") });
            StudentDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Nazwisko", Binding = new Binding("Surname") });
            StudentDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Nr Indeksu", Binding = new Binding("IndexNo") });
            StudentDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Wydział", Binding = new Binding("Faculty") });

            StudentDataGrid.AutoGenerateColumns = false;
            StudentDataGrid.ItemsSource = Students;
        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new StudentWindow();

            if(dialog.ShowDialog() == true)
            {
                Students.Add(dialog.Student);
                StudentDataGrid.Items.Refresh();
            }
        }

        private void RemoveStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if(StudentDataGrid.SelectedItem is Student)
            {
                Students.Remove((Student)StudentDataGrid.SelectedItem);
                StudentDataGrid.Items.Refresh();
            }
        }
    }
}
