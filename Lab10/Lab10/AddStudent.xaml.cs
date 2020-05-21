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

namespace Lab10
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        public Student Student { get; set; }

        public AddStudent()
        {
            InitializeComponent();
            Student = new Student();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Student = new Student { FirstName = NameTb.Text, SurName = SurnameTb.Text, Faculty = FacultyTb.Text };

            DialogResult = true;
        }
    }
}
