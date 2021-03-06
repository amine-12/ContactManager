﻿using System;
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
using LumenWorks.Framework.IO.Csv;
using System.Data;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Win32;
using System.Collections.Specialized;
using System.ComponentModel;
namespace ContactManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ContactDB db = ContactDB.Instance;
        MainViewModel main = new MainViewModel();
        public static ObservableCollection<Contact> contact = new ObservableCollection<Contact>();
        public MainWindow()
        {
            InitializeComponent();
            contact = db.ReadContact();
            DataContext = main;
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
            }
        }

        private void addContact_Click(object sender, RoutedEventArgs e)
        {
            AddContact addWindow = new AddContact();
            addWindow.Show();
        }

        //import
        private void importContact_Click(object sender, RoutedEventArgs e)
        {
            var csvData = new DataTable();

            var filePath = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "C:\\Users\\clomb\\Documents",
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*|CSV files (*.csv)|*.csv"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;
            }

            try //I added the LumenWorks CsvReader 4.0 to my visual studio to do this part. (add the NuGet if it doesn't work)
            {
                using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(filePath)), true))
                {
                    csvData.Load(csvReader);
                }
            }
            catch(ArgumentException)
            {
                Close();
            }

            List<Contact> importedContacts = new List<Contact>();

            for (int i = 0; i < csvData.Rows.Count; i++)
            {
                importedContacts.Add(new Contact
                {
                    FirstName = csvData.Rows[i][0].ToString(),
                    LastName = csvData.Rows[i][1].ToString(),
                    PhoneNumber = csvData.Rows[i][2].ToString(),
                    Address = csvData.Rows[i][3].ToString(),
                    Email = csvData.Rows[i][4].ToString(),
                });
            }

            foreach (Contact contact in importedContacts)
            {
                db.AddContact(contact);
                MainWindow.contact.Add(contact);
            }

        }
        //export
        private void exportContact_Click(object sender, RoutedEventArgs e)
        {
            var filePath = string.Empty;

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = "C:\\Users\\clomb\\Desktop",
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*|CSV files (*.csv)|*.csv"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                filePath = saveFileDialog.FileName;
            }
         

            string ConString = ConfigurationManager.ConnectionStrings["ContactConn"].ConnectionString;

            using(SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();

                SqlCommand command = new SqlCommand("SELECT * From Contact", con);

                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());

                try
                {
                    StreamWriter sw = new StreamWriter(filePath, false);

                    int countColumns = dt.Columns.Count;

                    for (int c = 0; c < countColumns; c++)
                    {
                        sw.Write(dt.Columns[c]);
                        if (c < countColumns - 1)
                        {
                            sw.Write(",");
                        }

                    }

                    sw.WriteLine();

                    foreach (DataRow dr in dt.Rows)
                    {
                        for (int r = 0; r < countColumns; r++)
                        {
                            if (!Convert.IsDBNull(dr[r]))
                            {
                                sw.Write(dr[r].ToString());
                            }
                            if (r < countColumns - 1)
                            {
                                sw.Write(",");
                            }

                        }

                        sw.WriteLine();
                    }

                    sw.Close();
                }
                catch (ArgumentException)
                {
                    Close();
                }

                MessageBox.Show("If the export file was saved, it will be found in the destination folder.", "SaveFile",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
