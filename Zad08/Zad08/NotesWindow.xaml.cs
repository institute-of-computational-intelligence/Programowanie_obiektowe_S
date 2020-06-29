using System.Collections.Generic;
using System.Windows;

namespace Zad08 {
    /// <summary>
    /// Logika interakcji dla klasy NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window {
        public List<Note> notes;
        public NotesWindow(List<Note> notes = null) {
            if (notes != null)
                this.notes = notes;
            else
                this.notes = new List<Note>();

            InitializeComponent();
            dg1.ItemsSource = this.notes;
        }

        private void notes_ok_button_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = true;
        }
    }
}
