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
    /// Logika interakcji dla klasy AddGrades.xaml
    /// </summary>
    public partial class AddGrades : Window
    {
        public Grades grades;
        public AddGrades(Grades grades = null)
        {
            InitializeComponent();
            if(grades!=null)
            {

                tbGrade.Text = grades.Grade.ToString();
                tbSubject.Text = grades.Subject;
            }
            this.grades = grades ?? new Grades();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            grades.Grade = int.Parse(tbGrade.Text);
            grades.Subject = tbSubject.Text;
            this.DialogResult = true;
        }
    }
}
