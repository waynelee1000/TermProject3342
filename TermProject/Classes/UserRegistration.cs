using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class UserRegistration
    {
        StoredProcedure storedProcedure = new StoredProcedure();

        public string registerUser(User user)
        {
            string IDExist = storedProcedure.chkUserExist(user.LoginID);
            if (IDExist == "False")
            {
                storedProcedure.addUser(user.LoginID, user.Password, user.Name, user.PhoneNumber, user.Address, user.ZipCode, user.City, user.State,
                    user.SecurityQuestion1, user.SecurityQuestion2, user.SecurityAnswer1, user.SecurityAnswer2);
                return "Account Created";
            }
            else
            {
                return "Login ID Already Exists. Please choose a different LoginID";
            }
        }
    }
}
