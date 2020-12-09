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
                        if (Int32.TryParse(reader["ID"].ToString(), out int id))
                            contact.ID = id;
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

        public int DeleteContact(int id)
        {
            int row = -1;

            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();

                string query = "DELETE FROM Contact WHERE ID=@id";

                SqlCommand cm = new SqlCommand(query, con);

                try
                {
                    cm.Parameters.AddWithValue("@id", id);
                    row = cm.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error. Details: " + e);
                }
            }
            return row;
        }

        public int UpdateContact(Contact contact)
        {
            int row = -1;

            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                string query = "UPDATE Contact SET FirstName = @firstName, LastName = @lastName, PhoneNumber = @phone, Address = @address, Email = @email WHERE Id=@id";

                SqlCommand cm = new SqlCommand(query, con);
                cm.Parameters.AddWithValue("@id", contact.ID);
                cm.Parameters.AddWithValue("@firstName", contact.FirstName);
                cm.Parameters.AddWithValue("@lastName", contact.LastName);
                cm.Parameters.AddWithValue("@phone", contact.PhoneNumber);
                cm.Parameters.AddWithValue("@address", contact.Address);
                cm.Parameters.AddWithValue("@email", contact.Email);
                try
                {
                    row = cm.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error. Details: " + e);
                }
            }
            return row;
        }
    }
}
