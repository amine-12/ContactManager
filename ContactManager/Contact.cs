using System;

namespace ContactManager
{
    class Contact
    {
        //public String FirstName { get; set { this.FirstName = FirstName + " "}; }
        private String firstName;

        public String FirstName
        {
            get { return firstName; }
            set { firstName = value + " "; }
        }

        private String lastName;

        public String LastName
        {
            get { return lastName; }
            set { lastName = value + " "; }
        }

        private String phoneNumber;

        public String PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value + " "; }
        }

        private String email;

        public String Email
        {
            get { return email; }
            set { email = value + " "; }
        }

        private String address;

        public String Address
        {
            get { return address; }
            set { address = value + " "; }
        }
    }
}
