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
    class StoredProcedure
    {
        DBConnect db = new DBConnect();

        public string chkUserExist(string loginID)
        {
            try
            {
                SqlCommand sqlChkUserExist = new SqlCommand();
                sqlChkUserExist.CommandType = CommandType.StoredProcedure;
                sqlChkUserExist.CommandText = "TP_GetUserAccount";
                sqlChkUserExist.Parameters.Add(new SqlParameter("@LoginID", loginID));

                DataSet mydata = db.GetDataSetUsingCmdObj(sqlChkUserExist);
                string ID = mydata.Tables[0].Rows[0][0].ToString();
                return ID;
            }
            catch
            {
                return "False";
            }
        }

        public void addUser(string loginID, string password, string name, string phoneNumber, string address, string securityQuestion1,
            string securityQuestion2, string securityAnswer1, string securityAnswer2)
        {
            SqlCommand sqlAddUser = new SqlCommand();
            sqlAddUser.CommandType = CommandType.StoredProcedure;
            sqlAddUser.CommandText = "TP_AddUser";
            sqlAddUser.Parameters.Add(new SqlParameter("@LoginID", loginID));
            sqlAddUser.Parameters.Add(new SqlParameter("@Password", password));
            sqlAddUser.Parameters.Add(new SqlParameter("@Name", name));
            sqlAddUser.Parameters.Add(new SqlParameter("@PhoneNumber", phoneNumber));
            sqlAddUser.Parameters.Add(new SqlParameter("@Address", address));
            sqlAddUser.Parameters.Add(new SqlParameter("@SecurityQuestion1", securityQuestion1));
            sqlAddUser.Parameters.Add(new SqlParameter("@SecurityQuestion2", securityQuestion2));
            sqlAddUser.Parameters.Add(new SqlParameter("@SecurityAnswer1", securityAnswer1));
            sqlAddUser.Parameters.Add(new SqlParameter("@SecurityAnswer2", securityAnswer2));

            db.DoUpdateUsingCmdObj(sqlAddUser);
        }

        public DataSet getFriend(string loginID)
        {
            DataSet myDS = new DataSet();
            try
            {
                SqlCommand sqlGetFriend = new SqlCommand();
                sqlGetFriend.CommandType = CommandType.StoredProcedure;
                sqlGetFriend.CommandText = "TP_GetFriend";
                sqlGetFriend.Parameters.Add(new SqlParameter("@LoginID", loginID));
                myDS = db.GetDataSetUsingCmdObj(sqlGetFriend);
                return myDS;
            }
            catch
            {
                return myDS;
            }

        }

        public DataSet getPreference(string loginID)
        {
            DataSet myDS = new DataSet();
            try
            {
                SqlCommand sqlGetPreference = new SqlCommand();
                sqlGetPreference.CommandType = CommandType.StoredProcedure;
                sqlGetPreference.CommandText = "TP_GetUserPreference";
                sqlGetPreference.Parameters.Add(new SqlParameter("@LoginID", loginID));
                myDS = db.GetDataSetUsingCmdObj(sqlGetPreference);
                return myDS;
            }
            catch
            {
                return myDS;
            }

        }

        public void updateLoginPreference(string loginID, string loginPrefernce)
        {
            SqlCommand sqlUpdateLoginPref = new SqlCommand();
            sqlUpdateLoginPref.CommandType = CommandType.StoredProcedure;
            sqlUpdateLoginPref.CommandText = "TP_UpdateLoginPref";
            sqlUpdateLoginPref.Parameters.Add(new SqlParameter("@LoginID", loginID));
            sqlUpdateLoginPref.Parameters.Add(new SqlParameter("@LoginPreference", loginPrefernce));

            db.DoUpdateUsingCmdObj(sqlUpdateLoginPref);
        }

        public DataSet checkLoginInfo(string loginID, string password)
        {
            DataSet loginDS = new DataSet();
            try
            {
                SqlCommand sqlCheckLogin = new SqlCommand();
                sqlCheckLogin.CommandType = CommandType.StoredProcedure;
                sqlCheckLogin.CommandText = "TP_CheckLogin";
                sqlCheckLogin.Parameters.Add(new SqlParameter("@theLoginID", loginID));
                sqlCheckLogin.Parameters.Add(new SqlParameter("thePassword", password));

                loginDS = db.GetDataSetUsingCmdObj(sqlCheckLogin);
                return loginDS;
            } 
            catch
            {
                return loginDS; 
            }
        }

        public DataSet getSecurity(string loginID)
        {
            DataSet securityDS = new DataSet();
            try
            {
                SqlCommand sqlCheckLogin = new SqlCommand();
                sqlCheckLogin.CommandType = CommandType.StoredProcedure;
                sqlCheckLogin.CommandText = "TP_GetSecurity";
                sqlCheckLogin.Parameters.Add(new SqlParameter("@theLoginID", loginID));

                securityDS = db.GetDataSetUsingCmdObj(sqlCheckLogin);
                return securityDS;
            }
            catch
            {
                return securityDS;
            }
        }
    }
}
