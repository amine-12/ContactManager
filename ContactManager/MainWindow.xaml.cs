using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
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
        ContactDB db = ContactDB.Instance;
        public static ObservableCollection<Contact> contact = new ObservableCollection<Contact>();
        public MainWindow()
        {
            InitializeComponent();
            contact = db.ReadContact();
            contactList.ItemsSource = contact;
            contactList.MouseDoubleClick +=  Display_Dbclick;
        }


        private void Display_Dbclick(object sender, RoutedEventArgs e)
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
            int index = contactList.SelectedIndex;
            if (index >= 0)
            {
                db.DeleteContact(contact[index].ID);
                contact.RemoveAt(index);
                foreach (var removedItem in contactList.SelectedItems)
                    (contactList.ItemsSource as ObservableCollection<Contact>).Remove((Contact)removedItem);
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
