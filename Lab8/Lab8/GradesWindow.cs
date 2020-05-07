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
using System.Windows.Shapes;

namespace Lab8
{
    /// <summary>
    /// Interaction logic for Grades.xaml
    /// </summary>
    public partial class GradesWindow : Window
    {
        private List<Grade> _grades; 

        public GradesWindow(List<Grade> grades)
        {
            InitializeComponent();

            _grades = grades;

            GradeDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Przedmiot", Binding = new Binding("Subject") });
            GradeDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Ocena", Binding = new Binding("Value") });

            GradeDataGrid.AutoGenerateColumns = false;
            GradeDataGrid.ItemsSource = grades;
        }

        private void AddGrade_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddGradeWindow();

            if (dialog.ShowDialog() == true)
            {
                _grades.Add(dialog.Grade);
                GradeDataGrid.Items.Refresh();
            }
        }

        private void RemoveGrade_Click(object sender, RoutedEventArgs e)
        {
            if (GradeDataGrid.SelectedItem is Grade)
            {
                _grades.Remove((Grade)GradeDataGrid.SelectedItem);
                GradeDataGrid.Items.Refresh();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
