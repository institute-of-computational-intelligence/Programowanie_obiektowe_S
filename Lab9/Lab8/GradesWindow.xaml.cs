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
    /// Logika interakcji dla klasy GradeWindow.xaml
    /// </summary>
    public partial class GradeWindow : Window
    {
        public GradeWindow(IList<Grade> grades)
        {
            InitializeComponent();
            gradesDg.Columns.Add(new DataGridTextColumn() { Header = "Ocena", Binding = new Binding("Value") });
            gradesDg.Columns.Add(new DataGridTextColumn() { Header = "Przedmiot", Binding = new Binding("Subject") });
            gradesDg.Columns.Add(new DataGridTextColumn() { Header = "Data", Binding = new Binding("Date") });
            gradesDg.AutoGenerateColumns = false;
            gradesDg.ItemsSource = grades;
        }
    }
}
