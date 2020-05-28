using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DBUtil db = new DBUtil();
        private List<Car> carsList;
        private List<Person> personsList;
        

        public MainWindow()
        {
            

            InitializeComponent();

            carsList = db.GetObjects<Car>();
            personsList = db.GetObjects<Person>();

            SetGrid<Car>(carsDG, carsList);
            SetGrid<Person>(personsDG, personsList);
        }

        private void SetGrid<T>(DataGrid dg, List<T> list)
        {
            Type t = typeof(T);
            if (t.GetCustomAttribute<DBTabAttribute>() == null)
                return;
            foreach (var p in t.GetProperties())
            {
                var coll = p.GetCustomAttribute<DBColAttribute>();
                if (coll != null)
                    dg.Columns.Add(new DataGridTextColumn() { Header = coll.Title ?? p.Name, Binding = new Binding(p.Name) });
            }

            dg.AutoGenerateColumns = false;
            dg.ItemsSource = list;
        }

        private void deleteCarButton_Click(object sender, RoutedEventArgs e)
        {
            if (carsDG.SelectedItem is Car)
            {
                Car car = carsDG.SelectedItem as Car;
                db.RemoveObject<Car>(car);
                carsList.Remove(car);
                carsDG.Items.Refresh();
            }
                
        }

        private void addCarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void filterCarsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deletePersonButton_Click(object sender, RoutedEventArgs e)
        {
            if(personsDG.SelectedItem is Person)
            {
                Person person = personsDG.SelectedItem as Person;
                db.RemoveObject<Person>(person);
                personsList.Remove(person);
                personsDG.Items.Refresh();
            }
        }

        private void addPersonButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new PersonWindow();
            if(dialog.ShowDialog() == true)
            {
                Person p = dialog.person;
                personsList.Add(p);
                db.InsertObject<Person>(p);
                personsDG.Items.Refresh();
            }
        }

        private void filterPersonsButton_Click(object sender, RoutedEventArgs e)
        {
            personsList = db.GetObjects<Person>(filterPersonsTB.Text);
            personsDG.ItemsSource = personsList;
            personsDG.Items.Refresh();
        }
    }
}
