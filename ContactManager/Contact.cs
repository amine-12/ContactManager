using System;
using System.ComponentModel;

namespace ContactManager
{
    public class Contact : ObservableObject
    {
        public int ID { get; set; }
        private string firstName;

        public string FirstName
        {
            get { return  firstName; }
            set 
            {  
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            { 
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public override string ToString()
        {
            return $"First Name: {FirstName}\nLast Name: {LastName}\nPhone Number: {PhoneNumber}\nAddress: {Address}\nEmail: {Email}";
        }
    }
}
