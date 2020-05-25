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
    /// Logika interakcji dla klasy GradesWindow.xaml
    /// </summary>
    public partial class GradesWindow : Window
    {
        IList<Grades> grade { get; set; }
        public GradesWindow()
        {
            grade = new List<Grades>()
            {
                new Grades(){Subject="",Grade=0}
            };
            InitializeComponent();
            t.Columns.Add(new DataGridTextColumn() { Header = "Ocena", Binding = new Binding("Value") });
             t.Columns.Add(new DataGridTextColumn() { Header = "Przedmiot", Binding = new Binding("Subject") });
            
            t.AutoGenerateColumns = false;
            t.ItemsSource = grade;
        }


    

        private void AddGrades_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddGrades();
            if (dialog.ShowDialog() == true)
            {
                grade.Add(dialog.grades);
                t.Items.Refresh();
            }
        }
    }
}
