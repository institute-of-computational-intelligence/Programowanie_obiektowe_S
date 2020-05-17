using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logika interakcji dla klasy OwnerWindow.xaml
    /// </summary>
    public partial class OwnerWindow : Window
    {
        public Owner owner;
        public OwnerWindow()
        {
            InitializeComponent();
            if (owner != null)
            {
                Pesel.Text = owner.Pesel;
                FirstName.Text = owner.FirstName;
                Surname.Text = owner.Surname;
            }
            owner = owner ?? new Owner();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(FirstName.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
               !Regex.IsMatch(Surname.Text, @"^\p{Lu}\p{Ll}{1,12}$"))
            {
                MessageBox.Show("Nie poprawne dane");
                return;
            }
            owner.Pesel = Pesel.Text;
            owner.FirstName = FirstName.Text;
            owner.Surname = Surname.Text;
            DialogResult = true;
        }
    }
}
