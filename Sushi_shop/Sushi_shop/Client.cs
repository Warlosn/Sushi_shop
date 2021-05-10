using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi_shop
{
    class Client
    {
        public int id_client { get; set; }
        private string email, firstname, lastname, adress, phone_number, pasword;
        public string Email {
            get { return email;}
            set { email = value; }
        }
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }
        public string Phone_number
        {
            get { return phone_number; }
            set { phone_number = value; }
        }
        public string Pasword
        {
            get { return pasword; }
            set { pasword = value; }
        }

        public Client() { }
        public Client(string email, string firstname, string lastname, string adress,  string phone_number, string pasword)
        {
            this.email = email;
            this.firstname = firstname;
            this.lastname = lastname;
            this.adress = adress;
            this.phone_number = phone_number;
            this.pasword = pasword;
        }
     }
}
