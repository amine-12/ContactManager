using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public List<Contact> ReadContact()
        {
            List<Contact> contactList = new List<Contact>();

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

        public void AddContact(string firstName, string lastName, string phone, string address, string email)
        {
            SqlConnection con = new SqlConnection(ConString);

            SqlCommand cm = new SqlCommand("INSERT INTO Contact (FirstName,LastName,PhoneNumber,Address,Email) VALUES(@firstName, @lastName, @phone, @address, @email)", con);

            cm.Parameters.AddWithValue("@firstName", firstName);
            cm.Parameters.AddWithValue("@lastName", lastName);
            cm.Parameters.AddWithValue("@phone", phone);
            cm.Parameters.AddWithValue("@address", address);
            cm.Parameters.AddWithValue("@email", email);

            try
            {
                con.Open();
                cm.ExecuteNonQuery();
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

    }
}
