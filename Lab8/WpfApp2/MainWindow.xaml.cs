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

namespace WpfApp2
{

    public partial class MainWindow : Window
    {
        public List<Student>Students {get; set;}
        public MainWindow()
        {
            Students = new List<Student>()
            {
                new Student(){Name="Jan",Surname="Kowalski",NoIndex=1033,Department="WIMII" },
                new Student(){Name="Michal",Surname="Nowak",NoIndex=1013,Department="WIMII" },
                new Student(){Name="Jacek",Surname="Makieta",NoIndex=1021, Department="WIMII" }
            };

            InitializeComponent();

            dg.Columns.Add(new DataGridTextColumn() { Header = "Imie", Binding = new Binding("Name") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Nazwisko", Binding = new Binding("Surname") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Numer indeksu", Binding = new Binding("NoIndex") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Wydzial", Binding = new Binding("Department") });
            dg.AutoGenerateColumns = false;
            dg.ItemsSource = Students;
        }



        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new StudentWindow();
            if(dialog.ShowDialog()==true)
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

        private void AddGarde_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowGrades_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
