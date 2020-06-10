using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Logika interakcji dla klasy NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
        public List<Note> notes;
        public NotesWindow(List<Note> notes = null)
        {
            if (notes != null)
                this.notes = notes;
            else
                this.notes = new List<Note>();
            
            InitializeComponent();
            dg1.ItemsSource = this.notes;
        }

        private void notes_ok_button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
