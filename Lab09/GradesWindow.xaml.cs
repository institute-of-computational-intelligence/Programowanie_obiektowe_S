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

namespace Lab08
{
    /// <summary>
    /// Interaction logic for GradesWindow.xaml
    /// </summary>
    public partial class GradesWindow : Window
    {
        public GradesWindow(Student student)
        {
            InitializeComponent();

            lblIndex.Content = student.IndexNumber;
            lblName.Content = student.Name;
            lblSurname.Content = student.Surname;

            dgGrades.Columns.Add(new DataGridTextColumn() { Header = "Subject", Binding = new Binding("Subject") });
            dgGrades.Columns.Add(new DataGridTextColumn() { Header = "Grade", Binding = new Binding("GradeValue") });

            dgGrades.IsReadOnly = true;
            dgGrades.CanUserAddRows = false;
            dgGrades.AutoGenerateColumns = false;
            dgGrades.ItemsSource = student?.GetGrades();
        }
    }
}
