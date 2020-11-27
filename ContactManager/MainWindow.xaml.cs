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
        List<Contact> contact = new List<Contact>();
        public MainWindow()
        {
            InitializeComponent();
            
            contact.Add(new Contact() { FirstName = "Bob", LastName = "Leponge ", PhoneNumber = "123 456 789", Email = "asads@gmail.com", Address = "123 Street" });
            contact.Add(new Contact() { FirstName = "Qwer", LastName = "Ty", PhoneNumber = "545 456 789", Email = "adaeds@gmail.com", Address = "12334 Street" });
            contact.Add(new Contact() { FirstName = "Tpop", LastName = "Hjkg", PhoneNumber = "123 516 789", Email = "gdsa@gmail.com", Address = "14223 Street" });
            contact.Add(new Contact() { FirstName = "Lojk", LastName = "Poip", PhoneNumber = "123 456 945", Email = "ertf@gmail.com", Address = "1473 Street" });

            contactList.ItemsSource = contact;
        }

        private void editContact_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteContact_Click(object sender, RoutedEventArgs e)
        {
           contact.RemoveAt(contactList.SelectedIndex);
            foreach (var removedItem in contactList.SelectedItems)
                (contactList.ItemsSource as List<Contact>).Remove((Contact)removedItem);
            contactList.Items.Refresh();

            //--DEBUG--
            Console.WriteLine(contactList.SelectedIndex);
            foreach(var x in contact)
                Console.WriteLine(x.ToString());
        }

        private void displayContact_Click(object sender, RoutedEventArgs e)
        {
            foreach (object o in contactList.SelectedItems)
            {
                MessageBox.Show("First Name: " + (o as Contact).FirstName +
                               "\nLast Name: " + (o as Contact).LastName +
                                "\nPhone Number: " + (o as Contact).PhoneNumber +
                                "\nAddress: " + (o as Contact).Address + 
                                "\nEmail: " + (o as Contact).Email);

            }
        }

        private void addContact_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
