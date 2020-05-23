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
                new Student(){ Surname = "Kowalski", Name = "Jan", IndexNumber = 1033, Major = "WIMiI" },
                new Student(){ Surname = "Nowak", Name = "Michał", IndexNumber = 1013, Major = "WIMiI" },
                new Student(){ Surname = "Makieta", Name = "Jacek", IndexNumber = 1021, Major = "WIMiI" }
            };

            InitializeComponent();

            StudentsDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Name", Binding = new Binding("Name") });
            StudentsDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Surname", Binding = new Binding("Surname") });
            StudentsDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Index Number", Binding = new Binding("IndexNumber") });
            StudentsDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Major", Binding = new Binding("Major") });
            StudentsDataGrid.AutoGenerateColumns = false;
            StudentsDataGrid.ItemsSource = list;
        }

        private void ButtonAddStudent_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new StudentWindow();
            if (dialog.ShowDialog() == true)
            {
                list.Add(dialog.student);
                StudentsDataGrid.Items.Refresh();
            }
        }

        private void ButtonRemoveStudent_Click(object sender, RoutedEventArgs e)
        {
            if (StudentsDataGrid.SelectedItem is Student)
                list.Remove((Student)StudentsDataGrid.SelectedItem);
            StudentsDataGrid.Items.Refresh();
        }
    }
}
