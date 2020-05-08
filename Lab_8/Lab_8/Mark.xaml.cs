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

namespace Lab_8
{
    /// <summary>
    /// Logika interakcji dla klasy Mark.xaml
    /// </summary>
    public partial class Marks : Window
    {

        private List<Grade> _marks;
        public Marks(List<Grade> marks)
        {
            InitializeComponent();

            _marks = marks;

            dgG.Columns.Add(new DataGridTextColumn() { Header = "Przedmiot", Binding = new Binding("Subject") });
            dgG.Columns.Add(new DataGridTextColumn() { Header = "Ocena", Binding = new Binding("Value") });

            dgG.AutoGenerateColumns = false;
            dgG.ItemsSource = marks;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void AddMarkButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddMarkWindow();

            if (dialog.ShowDialog() == true)
            {
                _marks.Add(dialog.Grade);
                dgG.Items.Refresh();
            }
        }
    }
}
