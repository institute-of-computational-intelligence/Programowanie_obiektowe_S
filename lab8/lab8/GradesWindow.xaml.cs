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
        public List<Grades> grade { get; set; }
        
        public GradesWindow()
        {
                grade = new List<Grades>()
            {
                new Grades(){Subject="programowanie", Grade=4, Index=1033},
                new Grades(){Subject="prograwanie", Grade=5, Index=1021}
            };
           
            List<Grades> found = grade.FindAll(oElement => oElement.Index.Equals(1021));
            InitializeComponent(); 
            t.Columns.Add(new DataGridTextColumn() { Header = "Przedmiot", Binding = new Binding("Subject") });
            t.Columns.Add(new DataGridTextColumn() { Header = "Ocena", Binding = new Binding("Grade") });
            
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
