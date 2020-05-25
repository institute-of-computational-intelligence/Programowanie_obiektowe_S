using Lab8.Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Lab8.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IList<Student> Students { get; set; }
        public MainWindow()
        {
            Students = new List<Student>
            {
                new Student(){FirstName = "Jan", SurName = "Kowalski", Faculty = "WIMII", StudentNo = 1010},
                new Student(){FirstName = "Michał", SurName = "Nowak", Faculty = "WIMII", StudentNo = 1011},
                new Student(){FirstName = "Jacek", SurName = "Makieta", Faculty = "WIMII", StudentNo = 1012},
            };
            InitializeComponent();
            dg_Students.Columns.Add(new DataGridTextColumn() { Header = "Imię", Binding = new Binding("FirstName") });
            dg_Students.Columns.Add(new DataGridTextColumn() { Header = "Nazwisko", Binding = new Binding("SurName") });
            dg_Students.Columns.Add(new DataGridTextColumn() { Header = "Wydział", Binding = new Binding("Faculty") });
            dg_Students.Columns.Add(new DataGridTextColumn() { Header = "NrIndeksu", Binding = new Binding("StudentNo") });
            dg_Students.Columns.Add(new DataGridTextColumn() { Header = "Oceny", Binding = new Binding("JoinedGrades") });
            dg_Students.AutoGenerateColumns = false;
            dg_Students.ItemsSource = Students;
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
                Students.Remove(studentToRemove);
                dg_Students.Items.Refresh();
            }
        }

        private void B_addGradeWindowShow_Click(object sender, RoutedEventArgs e)
        {
            if (dg_Students.SelectedItem != null && dg_Students.SelectedItem is Student selectedStudent)
            {
                var addGradeWindow = new AddGradeWindow(selectedStudent);
                if (addGradeWindow.ShowDialog() == true)
                    dg_Students.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Zaznacz studenta.");
            }
        }
    }
}
