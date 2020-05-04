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
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public IList<Student> Students { get; set; }
        public MainWindow()
        {
            Students = new List<Student>()
            {
                new Student("Jan", "Kowalski", 1033, "WIMiI"),
                new Student("Michał", "Nowak", 1013, "WIMiI"),
                new Student(){Surname = "Makieta", FirstName = "Jacek", IndexNumber = 1021, Faculty = "WIMiI"},
            };
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
            if(dialog.ShowDialog() == true)
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
            if(dg.SelectedItem is Student)
            {
                Student student = (Student)dg.SelectedItem;
                var dialog = new GradeWindow(student.Grades);
                if (dialog.ShowDialog() == true) ;
            }
        }

        private void AddGradeButton_Click(object sender, RoutedEventArgs e)
        {
            if(dg.SelectedItem is Student)
            {
                var dialog = new AddGradeWindow();

                if(dialog.ShowDialog() == true)
                {
                    var student = (Student)dg.SelectedItem;
                    student.Grades.Add(dialog.grade);
                }
            }
        }
    }
}
