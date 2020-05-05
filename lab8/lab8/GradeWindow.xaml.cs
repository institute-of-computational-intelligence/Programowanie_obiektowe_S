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

namespace lab8
{
    /// <summary>
    /// Logika interakcji dla klasy GradeWindow.xaml
    /// </summary>
    public partial class GradeWindow : Window
    {
        List<Grade> Grades;
        public GradeWindow()
        {
            InitializeComponent();
            dg.Columns.Add(new DataGridTextColumn() { Header = "Przedmiot", Binding = new Binding("Subject") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Ocena", Binding = new Binding("Value") });
            dg.AutoGenerateColumns = false;
        }
        public GradeWindow(Student selectedStudent)
        {
            InitializeComponent();
            tbStudentsData.Text = $"Oceny studenta:\n" +
                $"{selectedStudent.FirstName} {selectedStudent.LastName}\n" +
                $"Nr indeksu: {selectedStudent.IndexNo.ToString()}\n" +
                $"Wydział: {selectedStudent.Faculty}";
            Grades = selectedStudent.Grades;
            dg.Columns.Add(new DataGridTextColumn() { Header = "Przedmiot", Binding = new Binding("Subject") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Ocena", Binding = new Binding("Value") });
            dg.AutoGenerateColumns = false;
            dg.ItemsSource = selectedStudent.Grades;
        }
    }
}
