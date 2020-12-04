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
using System.Windows.Shapes;

namespace ContactManager
{
    /// <summary>
    /// Interaction logic for AddContact.xaml
    /// </summary>
    public partial class AddContact : Window
    {
        public AddContact()
        {
            InitializeComponent();
        }
        private void Add_click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            var db = ContactDB.Instance;
            db.AddContact(firstNameAdd.Text, lastNameAdd.Text, phoneAdd.Text, addressAdd.Text, emailAdd.Text);
            MainWindow.contact = db.ReadContact();
            main.contactList.ItemsSource = MainWindow.contact;
            Close();
        }
    }
}
