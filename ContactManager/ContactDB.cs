using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;

namespace ContactManager
{
    class ContactDB
    {
        string ConString = ConfigurationManager.ConnectionStrings["ContactConn"].ConnectionString;
        ContactDB() { }
        static readonly ContactDB instance = new ContactDB();
        public static ContactDB Instance
        {
            get { return instance; }
        }
        public ObservableCollection<Contact> ReadContact()
        {
            ObservableCollection<Contact> contactList = new ObservableCollection<Contact>();

            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand cm = new SqlCommand("Select * from Contact", con);

                using (SqlDataReader reader = cm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Contact contact = new Contact();
                        //sales.Name = reader["Name"].ToString();
                        contact.FirstName = reader["FirstName"].ToString();
                        contact.LastName = reader["LastName"].ToString();
                        contact.PhoneNumber = reader["PhoneNumber"].ToString();
                        contact.Email = reader["Email"].ToString();
                        contact.Address = reader["Address"].ToString();
                        contactList.Add(contact);
                    }
                }
            }
            return contactList;
        }

        public int AddContact(Contact contact)
        {
            int newID = 0;
            int row = 1;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                string query = "INSERT INTO Contact (FirstName,LastName,PhoneNumber,Address,Email) VALUES(@firstName, @lastName, @phone, @address, @email)";

                SqlCommand cm = new SqlCommand(query, con);

                cm.Parameters.AddWithValue("@firstName", contact.FirstName);
                cm.Parameters.AddWithValue("@lastName", contact.LastName);
                cm.Parameters.AddWithValue("@phone", contact.PhoneNumber);
                cm.Parameters.AddWithValue("@address", contact.Address);
                cm.Parameters.AddWithValue("@email", contact.Email);

                try
                {
                    row = cm.ExecuteNonQuery();
                    string query2 = "select @@Identity as NewId from Contact";
                    cm.CommandText = query2;
                    cm.Connection = con;
                    newID = Convert.ToInt32(cm.ExecuteScalar());
                    Console.WriteLine($"Records Inserted Successfully");

                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e);
                }
                finally
                {
                    con.Close();
                }

            }
            return newID;

        }

        public void DeleteContact(List<Contact> contacts,int id)
        {

            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand cm = new SqlCommand("DELETE from Contact WHERE ID=@id", con);
                using (SqlDataReader reader = cm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Contact contact = new Contact();
                        if (Int32.TryParse(reader["SKU"].ToString(), out int ID))
                            contact.ID = ID;

                    }
                }
                cm.Parameters.AddWithValue("@id", id);
                contacts.RemoveAt(id);
            }
        }


    }
}
