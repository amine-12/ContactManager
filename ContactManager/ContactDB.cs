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

    }
}
