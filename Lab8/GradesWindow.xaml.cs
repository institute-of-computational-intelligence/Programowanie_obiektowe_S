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
    /// Interaction logic for GradesWindow.xaml
    /// </summary>
    public partial class GradesWindow : Window
    {
        public List<Grade> grades;

        public GradesWindow(List<Grade> grades = null)
        {
            if (grades != null)
                this.grades = grades;
            else
                this.grades = new List<Grade>();

            InitializeComponent();
            gradesDG.ItemsSource = this.grades;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
