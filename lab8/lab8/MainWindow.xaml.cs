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
        public Student SelectedStudent { get; set; }
        public MainWindow()
        {
            list = new List<Student>()
            {
                new Student(){LastName="Kowalski", FirstName = "Jan", IndexNo = 1033, Faculty = "WIMiI" },
                new Student(){LastName="Nowak", FirstName = "Michał", IndexNo = 1013, Faculty = "WIMiI" },
                new Student(){LastName="Makieta", FirstName = "Jacek", IndexNo = 1021, Faculty = "WIMiI" }
            };

            InitializeComponent();

            dg.Columns.Add(new DataGridTextColumn() { Header = "Imię", Binding = new Binding("FirstName") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Nazwisko", Binding = new Binding("LastName") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "NrIndeksu", Binding = new Binding("IndexNo") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Wydział", Binding = new Binding("Faculty") });
            dg.AutoGenerateColumns = false;
            dg.ItemsSource = list;
        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new StudentWindow();
            if (dialog.ShowDialog() == true)
            {
                list.Add(dialog.student);
                dg.Items.Refresh();
            }
        }

        private void RemoveStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem is Student)
                list.Remove((Student)dg.SelectedItem);
            dg.Items.Refresh();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dg.SelectedIndex < list.Count)
                SelectedStudent = (Student)dg.SelectedItem;
        }

        private void ShowGradesButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedStudent == null)
                MessageBox.Show("Wybierz studenta z listy");
            else
            {
                var dialog = new GradeWindow(SelectedStudent);
                dialog.Show();
            }

        }

        private void AddGradeButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedStudent == null)
                MessageBox.Show("Wybierz studenta z listy");
            else
            {
                var dialog = new AddGradeWindow(SelectedStudent);
                dialog.ShowDialog();
            }
        }
    }
}
