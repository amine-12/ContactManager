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
        AddContact addContactClose = new AddContact();
        public MainWindow()
        {
            InitializeComponent();
            
            var db = ContactDB.Instance;
            contact = db.ReadContact();
            contactList.ItemsSource = contact;
            contactList.MouseDoubleClick +=  HandleDoubleClick;
        }

        private void Addc_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("works!!");
            contactList.ItemsSource = contact;
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
            addContactClose.Closed += Addc_Closed;
            AddContact addWindow = new AddContact();
            addWindow.Show();
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            contactList.ItemsSource = contact;
        }

        //public static void refresh()
        //{
        //    MainWindow main = new MainWindow();
        //    main.contactList.ItemsSource = contact;
        //}

    }
}
