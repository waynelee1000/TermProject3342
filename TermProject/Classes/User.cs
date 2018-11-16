﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class User
    {
        public string LoginID { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string SecurityQuestion1 { get; set; }
        public string SecurityQuestion2 { get; set; }
        public string SecurityAnswer1 { get; set; }
        public string SecurityAnswer2 { get; set; }

        public User()
        {

        }
        public User(string loginID, string password, string name, string phoneNumber, string address, string securityQuestion1, 
            string securityQuestion2, string securityAnswer1, string securityAnswer2)
        {
            this.LoginID = loginID;
            this.Password = password;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.SecurityQuestion1 = securityQuestion1;
            this.SecurityQuestion2 = securityQuestion2;
            this.SecurityAnswer1 = securityAnswer1;
            this.SecurityAnswer2 = securityAnswer2;
        }

    }
}
