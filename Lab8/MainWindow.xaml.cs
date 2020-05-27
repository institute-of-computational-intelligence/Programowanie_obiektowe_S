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
        public List<Student> list { get; set; }

        public MainWindow()
        {
            list = new List<Student>()
            {
                new Student(){ Name = "Jan", Surname = "Pan", Index = 2135, Subject="IT"},
                new Student(){ Name = "Ala", Surname = "Dam", Index = 2136, Subject="IT"},
                new Student(){ Name = "Ola", Surname = "Pani", Index = 2137, Subject="IT"}
            };
            InitializeComponent();
            dg.Columns.Add(new DataGridTextColumn() { Header = "Imię", Binding = new Binding("Name") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Nazwisko", Binding = new Binding("Surname") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Nr Indeksu", Binding = new Binding("Index") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Kierunek", Binding = new Binding("Subject") });
            dg.AutoGenerateColumns = false;
            dg.ItemsSource = list;
            dg.CanUserAddRows = false;
            
        }

        private void addStudentButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new StudentWindow();
            if(dialog.ShowDialog() == true)
            {
                list.Add(dialog.student);
                dg.Items.Refresh();
            }
        }

        private void removeStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem is Student)
                list.Remove(dg.SelectedItem as Student);
            dg.Items.Refresh();
        }

        private void showGradesButton_Click(object sender, RoutedEventArgs e)
        {
            if(dg.SelectedItem is Student)
            {
                Student student = (Student) dg.SelectedItem;
                var dialog = new GradesWindow(student.Grades);
                if(dialog.ShowDialog() == true)
                {
                    student.Grades = dialog.grades;
                }
            }

        }

        private void addGradeButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem is Student)
            {
                Student student = (Student)dg.SelectedItem;
                var dialog = new AddGradeWindow();
                if (dialog.ShowDialog() == true)
                {
                    student.Grades.Add(dialog.grade);
                }
            }
        }
    }
}
