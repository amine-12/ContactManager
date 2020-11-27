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
            MainWindow main = new MainWindow();
            firstName.Content = main.GetList()[index].FirstName;
            lastName.Content = main.GetList()[index].LastName;
            phone.Content = main.GetList()[index].PhoneNumber;
            address.Content = main.GetList()[index].Address;
            email.Content = main.GetList()[index].Email;
        }
    }
}
