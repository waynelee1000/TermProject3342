using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using System.Data.SqlClient;
using System.Data;

namespace Classes
{
    public class UserLogin
    {
        StoredProcedure storedProcedure = new StoredProcedure();

        public string loginUser(string loginID, string password)
        {
            DataSet ds = new DataSet();
            ds = storedProcedure.checkLoginInfo(loginID, password);

            if (ds == null )
            {
                return "Error";
            }
            else
            {
                return loginID;
            }
        }
    }
}

