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
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public int INDEX { get; set; }
        public Contact contactUpdate { get; set; }
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
            var db = ContactDB.Instance;
            MainWindow.contact[INDEX].FirstName = firstNameEdit.Text;
            MainWindow.contact[INDEX].LastName = lastNameEdit.Text;
            MainWindow.contact[INDEX].PhoneNumber = phoneEdit.Text;
            MainWindow.contact[INDEX].Address = addressEdit.Text;
            MainWindow.contact[INDEX].Email = emailEdit.Text;
            db.UpdateContact(MainWindow.contact[INDEX]);
            Close();
        }
    }
}