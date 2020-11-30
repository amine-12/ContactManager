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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Contact> contact = new List<Contact>();
        public MainWindow()
        {
            InitializeComponent();
            
            contact.Add(new Contact() { FirstName = "Bob", LastName = "Leponge ", PhoneNumber = "123 456 789", Email = "asads@gmail.com", Address = "123 Street" });
            contact.Add(new Contact() { FirstName = "Qwer", LastName = "Ty", PhoneNumber = "545 456 789", Email = "adaeds@gmail.com", Address = "12334 Street" });
            contact.Add(new Contact() { FirstName = "Tpop", LastName = "Hjkg", PhoneNumber = "123 516 789", Email = "gdsa@gmail.com", Address = "14223 Street" });
            contact.Add(new Contact() { FirstName = "Lojk", LastName = "Poip", PhoneNumber = "123 456 945", Email = "ertf@gmail.com", Address = "1473 Street" });
            contactList.ItemsSource = contact;
            contactList.MouseDoubleClick +=  HandleDoubleClick;
        }

        private void HandleDoubleClick(object sender, RoutedEventArgs e)
        {
            if (contactList.SelectedIndex >= 0)
            {
                DisplayContact displayContact = new DisplayContact(contactList.SelectedIndex);
                displayContact.Show();
            }
        }

        private void editContact_Click(object sender, RoutedEventArgs e)
        {
            if (contactList.SelectedIndex >= 0)
            {
                EditWindow editWindow = new EditWindow(contactList.SelectedIndex);
                editWindow.Show();
            }
            
        }
        
        
        private void deleteContact_Click(object sender, RoutedEventArgs e)
        {
            
            if (contactList.SelectedIndex >= 0)
            {
                contact.RemoveAt(contactList.SelectedIndex);
                foreach (var removedItem in contactList.SelectedItems)
                {
                    (contactList.ItemsSource as List<Contact>).Remove((Contact)removedItem);
                }
            }

            contactList.Items.Refresh();
          
            //foreach (var x in contact)
            //{
            //    Console.WriteLine(x.ToString());
            //    Console.WriteLine("----------------------");
            //}
        }

        private void addContact_Click(object sender, RoutedEventArgs e)
        {
            AddContact addWindow = new AddContact();
            addWindow.Show();
        }

    }
}
