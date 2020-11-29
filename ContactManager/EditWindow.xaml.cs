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
        public EditWindow(int index)
        {
            InitializeComponent();
            firstNameEdit.Text = MainWindow.contact[index].FirstName;
            lastNameEdit.Text = MainWindow.contact[index].LastName;
            phoneEdit.Text = MainWindow.contact[index].PhoneNumber;
            addressEdit.Text = MainWindow.contact[index].Address;
            emailEdit.Text = MainWindow.contact[index].Email;

        }
    }
}
