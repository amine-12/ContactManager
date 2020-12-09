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
    /// Interaction logic for DisplayContact.xaml
    /// </summary>
    public partial class DisplayContact : Window
    {
        public DisplayContact(int index)
        {
            InitializeComponent();
            firstName.Text = MainWindow.contact[index].FirstName;
            lastName.Text = MainWindow.contact[index].LastName;
            phone.Text = MainWindow.contact[index].PhoneNumber;
            address.Text = MainWindow.contact[index].Address;
            email.Text = MainWindow.contact[index].Email;
            
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
