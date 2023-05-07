using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App4
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Crear lista de contactos
            var contacts = new List<Contact>
            {
                new Contact { FirstName = "John", LastName = "Doe"},
                new Contact { FirstName = "Jane", LastName = "Doe" },
                new Contact { FirstName = "Bob", LastName = "Smith" },
                new Contact { FirstName = "Sally", LastName = "Smith" },
                new Contact { FirstName = "Hubert", LastName = "Bahringer" },
                new Contact { FirstName = "Montana", LastName = "Bernier" },
                new Contact { FirstName = "Danika", LastName = "Col" },
                new Contact { FirstName = "Caitlyn", LastName = "Casper" },
                new Contact { FirstName = "Woodrow", LastName = "Cruickshank" },
                new Contact { FirstName = "Florida", LastName = "Gleichner" },
                new Contact { FirstName = "Cristina", LastName = "Hand" },
                new Contact { FirstName = "Myrna", LastName = "Hacket" },
                new Contact { FirstName = "Carolyne", LastName = "Kovacek" }
            };

            // Agrupar contactos por primera letra del apellido
            var contactsGrouped = new ObservableCollection<Grouping<string, Contact>>(
                contacts.OrderBy(c => c.LastName)
                        .ThenBy(c => c.FirstName)
                        .GroupBy(c => c.LastName?.Substring(0, 1).ToUpper())
                        .Select(g => new Grouping<string, Contact>(g.Key, g)));

            // Asignar la lista agrupada al ListView
            listView.ItemsSource = contactsGrouped;
        }
    }
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Grouping<K, T> : ObservableCollection<T>
    {
        public K Key { get; private set; }

        public Grouping(K key, IEnumerable<T> items)
        {
            Key = key;
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
    }
}
