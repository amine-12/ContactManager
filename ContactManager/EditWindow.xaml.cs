using System.Windows;
using System;

namespace ContactManager
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public static int INDEX { get; set; }
        public static Contact Contact { get; set; }
        public EditWindow(int index)
        {
            InitializeComponent();
            INDEX = index;
            firstNameEdit.Text = MainWindow.contact[index].FirstName;
            lastNameEdit.Text = MainWindow.contact[index].LastName;
            phoneEdit.Text = MainWindow.contact[index].PhoneNumber;
            addressEdit.Text = MainWindow.contact[index].Address;
            emailEdit.Text = MainWindow.contact[index].Email;

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //Contact contact = new Contact();
            //MainWindow main = new MainWindow();
            //MainWindow.contact[INDEX].FirstName = firstNameEdit.Text;
            //MainWindow.contact[INDEX].LastName = lastNameEdit.Text;
            //MainWindow.contact[INDEX].PhoneNumber = phoneEdit.Text;
            //MainWindow.contact[INDEX].Address = addressEdit.Text;
            //MainWindow.contact[INDEX].Email = emailEdit.Text;
            //var db = ContactDB.Instance;
            //db.UpdateContact(MainWindow.contact[INDEX]);
            //MainWindow.contact = db.ReadContact();


            //contact.FirstName = firstNameEdit.Text;
            //contact.LastName = lastNameEdit.Text;
            //contact.PhoneNumber = phoneEdit.Text;
            //contact.Address = addressEdit.Text;
            //contact.Email = emailEdit.Text;

            //Console.WriteLine(MainWindow.contact[INDEX]);
            //Close();
            MainWindow main = new MainWindow();
            MainWindow.contact[INDEX].FirstName = firstNameEdit.Text;
            MainWindow.contact[INDEX].LastName = lastNameEdit.Text;
            MainWindow.contact[INDEX].PhoneNumber = phoneEdit.Text;
            MainWindow.contact[INDEX].Address = addressEdit.Text;
            MainWindow.contact[INDEX].Email = emailEdit.Text;
            var db = ContactDB.Instance;
            db.UpdateContact(MainWindow.contact[INDEX]);
            MainWindow.contact = db.ReadContact();
            Console.WriteLine(INDEX);
            
            //Contact[] contact = new Contact[main.contactList.Items.Count];

            for(int i = 0; i < main.contactList.Items.Count - 1; i++)
            {
                //Console.WriteLine(main.contactList.Items.Count);
                //Console.WriteLine(i + " S");
                //contact[i] = new Contact();
                //contact[i].FirstName = firstNameEdit.Text;
                //contact[i].LastName = lastNameEdit.Text;
                //contact[i].PhoneNumber = phoneEdit.Text;
                //contact[i].Address = addressEdit.Text;
                //contact[i].Email = emailEdit.Text;
                //MainWindow.contact[INDEX] = contact[i];
                Contact contact = new Contact();
                contact.FirstName = firstNameEdit.Text;
                contact.LastName = lastNameEdit.Text;
                contact.PhoneNumber = phoneEdit.Text;
                contact.Address = addressEdit.Text;
                contact.Email = emailEdit.Text;
                MainWindow.contact[INDEX] = contact;
            }

            Console.WriteLine(MainWindow.contact[INDEX]);
            Close();
        }
    }
}
