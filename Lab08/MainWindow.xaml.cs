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

namespace Lab08
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public IList<Student> StudentList { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            StudentList = new List<Student>()
            {
                new Student() { Name = "Janusz", Surname = "Kowalski", IndexNumber = 18621, Faculty = "WIMiI" },
                new Student() { Name = "Andrzej", Surname = "Nowak", IndexNumber = 13528, Faculty = "WIMiI" },
                new Student() { Name = "John", Surname = "Doe", IndexNumber = 16322, Faculty = "WIMiI" },
            };

            studentsGrid.Columns.Add(new DataGridTextColumn() { Header = "Name", Binding = new Binding("Name") });
            studentsGrid.Columns.Add(new DataGridTextColumn() { Header = "Surname", Binding = new Binding("Surname") });
            studentsGrid.Columns.Add(new DataGridTextColumn() { Header = "Index number", Binding = new Binding("IndexNumber") });
            studentsGrid.Columns.Add(new DataGridTextColumn() { Header = "Faculty", Binding = new Binding("Faculty") });

            studentsGrid.IsReadOnly = true;
            studentsGrid.CanUserAddRows = false;
            studentsGrid.AutoGenerateColumns = false;
            studentsGrid.ItemsSource = StudentList;
        }

        private void btnRemoveStudent_Click(object sender, RoutedEventArgs e)
        {
            if (studentsGrid.SelectedItem != null && studentsGrid.SelectedItem is Student)
                StudentList.Remove((Student)studentsGrid.SelectedItem);

            studentsGrid.Items.Refresh();
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            StudentWindow dialog = new StudentWindow();

            if (dialog.ShowDialog() == true)
            {
                StudentList.Add(dialog.student);
                studentsGrid.Items.Refresh();
            }
        }

        private void btnAddGrade_Click(object sender, RoutedEventArgs e)
        {
            if (studentsGrid.SelectedItem is Student)
            {
                NewGradeWindow gradeDialog = new NewGradeWindow((Student)studentsGrid.SelectedItem);
                gradeDialog.ShowDialog();
            }
        }

        private void btnShowGrades_Click(object sender, RoutedEventArgs e)
        {
            if (studentsGrid.SelectedItem is Student)
            {
                GradesWindow gradeDialog = new GradesWindow((Student)studentsGrid.SelectedItem);
                gradeDialog.ShowDialog();
            }
        }
    }
}
